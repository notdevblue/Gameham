using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commands.Movement;
using Player.Status;

namespace Player.Movement
{
    /// <summary>
    /// �⺻���� �������� ������ Ŭ����
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour, IMoveable
    {
        private Rigidbody rigid;

        /// <summary>
        /// �̵� �� ȣ���. Vector3 = direction<br/>
        /// �Է� Ű ������ ���� ��� ȣ���
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

            // Space.World �߰��ϴ� �� ������!
            transform.Translate(dir * PlayerValues.Instance.speed * Time.deltaTime, Space.World);
            OnMove(dir);
        }
    }
}