using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Server.Core;
using Server.VO;
using Server.UI;

namespace Objects.UI
{
    public class RoomInstanceManager : MonoBehaviour
    {
        [SerializeField] private GameObject _roomInstance;
        [SerializeField] private Transform _instantiateParent;

        private bool flag = false;
        RoomQueryVO vo;

        private void Awake()
        {
            BufferHandler.Instance.Add("roomquery", data => {
                vo = JsonUtility.FromJson<RoomQueryVO>(data);
                Debug.Log(vo == null);
                if(vo == null) return;

                flag = true;
            });

            StartCoroutine(ResetRoom());
        }

        IEnumerator ResetRoom()
        {
            while (true)
            {
                yield return new WaitUntil(() => flag);

                for (int i = _instantiateParent.childCount - 1; i >= 0; ++i) {
                    Destroy(_instantiateParent.GetChild(i).gameObject);
                }

                vo.roomData.ForEach(room => {
                    ConnectButton btn = Instantiate(_roomInstance, _instantiateParent).GetComponent<ConnectButton>();
                    btn.Init(room.roomNumber, room.players.Count);
                });

                flag = false;
            }
        }
    }
}