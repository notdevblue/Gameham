using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Commands.Movement
{
    /// <summary>
    /// �⺻���� wasd �������� �̿��ϱ� ���� Interface
    /// </summary>
    public interface IMoveable
    {
        public void MoveUp();
        public void MoveDown();
        public void MoveLeft();
        public void MoveRight();
    }
}