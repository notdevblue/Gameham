using UnityEngine;

namespace Player.Status
{
    public class PlayerStatus : Singleton<PlayerStatus>, ISingletonObject
    {
        // ���� ����
        public bool IsMoving { get; set; } = false;

        // �÷��� ����
        public bool Damaged { get; set; } = false;

        // �ൿ ���� ���� ����
        public bool Moveable { get; set; } = true;
    }

}