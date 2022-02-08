using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commands;

namespace Player.Bullets
{
    public class TestBullet : BulletCommand
    {
        IBullets _bullets;

        public TestBullet(IBullets bullets)
        {
            _bullets = bullets;
        }

        public override void Delete()
        {
            // 총알 삭제 구문 작성
        }

        public override void Execute()
        {
            _bullets.Test();
        }
    }

    // 이후 무기 추가될수록 추가 작성 할거임
}