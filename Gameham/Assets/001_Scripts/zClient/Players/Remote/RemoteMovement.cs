using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Server.Client.Core;
using Server.Core;
using Server.VO;

namespace Player.Movement.Remote
{
    [RequireComponent(typeof(ClientBase))]
    public class RemoteMovement : MonoBehaviour
    {
        [SerializeField] private float _posSendDelta = 0.10f;

        ClientBase _clientBase;
        WaitForSeconds _wait;

        private bool _sendPosition;
        public bool SendPosition {
            get => _sendPosition;
            set {
                _sendPosition = value;
                switch(_sendPosition)
                {
                    case true:
                        StartCoroutine(Send());
                        break;
                    case false:
                        StopCoroutine(Send());
                        break;
                }
            }
        }

        private void Awake()
        {
            _clientBase = GetComponent<ClientBase>();
            SendPosition = true;
            _wait = new WaitForSeconds(_posSendDelta);
        }

        IEnumerator Send()
        {
            while(SendPosition)
            {
                string payload = JsonUtility.ToJson(new MoveVO(_clientBase.ID, this.transform.position));
                SocketCore.Instance.Send(new DataVO("move", payload));
                yield return _wait;
            }
        }
    }
}