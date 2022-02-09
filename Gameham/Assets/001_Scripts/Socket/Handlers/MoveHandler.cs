using UnityEngine;
using Server.Core;
using Server.VO;
using Server.Client.Core;

namespace Server.Handler
{
    /// <summary>
    /// move 이벤트 받는 오브젝트 용
    /// </summary>
    public class MoveHandler : MonoBehaviour
    {
        [SerializeField] private float _lerpAmount = 0.05f;

        private Vector2 _targetPos;

        private void Awake()
        {
            ClientBase clientBase = GetComponent<ClientBase>();
            _targetPos = this.transform.position;

            BufferHandler.Instance.Add("move", data => {
                MoveVO vo = JsonUtility.FromJson<MoveVO>(data);

                if (clientBase.ID.CompareTo(vo.id) == 0) {
                    _targetPos = vo.pos;
                }
            }, true);
        }


        private void Update()
        {
            transform.position = Vector2.Lerp(transform.position, _targetPos, _lerpAmount);
        }
    }
}