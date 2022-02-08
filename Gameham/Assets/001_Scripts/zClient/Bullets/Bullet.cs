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
            // �Ѿ� ���� ���� �ۼ�
        }

        public override void Execute()
        {
            _bullets.Test();
        }
    }

    // ���� ���� �߰��ɼ��� �߰� �ۼ� �Ұ���
}