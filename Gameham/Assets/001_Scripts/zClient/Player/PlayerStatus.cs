using UnityEngine;

namespace Player.Status
{
    public class PlayerStatus : Singleton<PlayerStatus>, ISingletonObject
    {
        // 상태 변수
        public bool IsMoving { get; set; } = false;

        // 플레그 변수
        public bool Damaged { get; set; } = false;

        // 행동 가능 상태 변수
        public bool Moveable { get; set; } = true;
    }

}