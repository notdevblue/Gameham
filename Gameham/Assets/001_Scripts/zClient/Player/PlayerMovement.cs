using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commands.Movement;
using Player.Status;

namespace Player.Movement
{
    /// <summary>
    /// 기본적인 움직임을 구현한 클레스
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour, IMoveable
    {
        private Rigidbody rigid;

        /// <summary>
        /// 이동 시 호출됨. Vector3 = direction<br/>
        /// 입력 키 누르는 동안 계속 호출됨
        /// </summary>
        public event System.Action<Vector3> OnMove;

        private void Awake()
        {
            OnMove += (dir) => { };
            rigid = GetComponent<Rigidbody>();
        }

        public void MoveUp()
        {
            Move(transform.up);
        }

        public void MoveDown()
        {
            Move(-transform.up);
        }

        public void MoveLeft()
        {
            Move(-transform.right);
        }

        public void MoveRight()
        {
            Move(transform.right);
        }

        private void Move(Vector3 dir)
        {
            if (!PlayerStatus.Instance.Moveable) return;

            // Space.World 추가하는 거 수정함!
            transform.Translate(dir * PlayerValues.Instance.speed * Time.deltaTime, Space.World);
            OnMove(dir);
        }
    }
}