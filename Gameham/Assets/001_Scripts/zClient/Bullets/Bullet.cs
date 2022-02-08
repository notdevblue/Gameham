using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commands;
using Player.Bullets.Pool;

namespace Player.Bullets
{
    public class TestBullet : BulletCommand
    {
        IBullets _bullets;
        GameObject testPrefab;

        public TestBullet(IBullets bullets)
        {
            _bullets = bullets;

            // �׽�Ʈ�� Ǯ ������� ��
        }

        public override void Delete()
        {
            // �Ѿ� ���� ���� �ۼ�
        }

        public override void Fire()
        {
            _bullets.Test();
        }
    }

    public class ArrowBullet : BulletCommand
    {
        IBullets _bullets;
        GameObject _arrowPrefab;

        public ArrowBullet(IBullets bullets, GameObject arrowPrefab, Transform parent)
        {
            _bullets = bullets;
            _arrowPrefab = arrowPrefab;

            PoolManager.CreatePool<ArrowPool>(_arrowPrefab, parent, 100);
        }

        public override void Delete()
        {
            // �Ѿ� ���� ���� �ۼ�
        }

        public override void Fire()
        {
            _bullets.Arrow();
        }
    }
    // ���� ���� �߰��ɼ��� �߰� �ۼ� �Ұ���
}