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

        public override float fireDelay => -1;
        public override float bulletSpeed => -1;
        public override int damage => -1;

        public override void Delete()
        {
            // �Ѿ� ���� ���� �ۼ�
        }

        public override void SendFire()
        {
            // �Ѿ��� ��ٰ� �������� ����
        }

        public override void RealFire()
        {
            // �Ѿ� ��ȯ
        }

        public override void EffectFire()
        {
            // �����ֱ�� �Ѿ� ��ȯ
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

        public override float fireDelay => 3;
        public override float bulletSpeed => 2;
        public override int damage => 10;

        public override void Delete()
        {
            // �Ѿ� ���� ���� �ۼ�
        }
        public override void SendFire()
        {
            _bullets.Arrow(bulletSpeed, damage);
        }
        public override void RealFire()
        {
            // �Ѿ� �߻��ϴ� �ڵ� �ۼ���
            ArrowPool pool = PoolManager.GetItem<ArrowPool>(_arrowPrefab);
            
            pool.gameObject.AddComponent<BoxCollider2D>();
        }

        public override void EffectFire()
        {
            // �����ֱ�� �Ѿ� �߻��ϴ� �ڵ� �ۼ��Ұ���
            ArrowPool pool = PoolManager.GetItem<ArrowPool>(_arrowPrefab);
        }
    }
    // ���� ���� �߰��ɼ��� �߰� �ۼ� �Ұ���
}