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

            // 테스트용 풀 만들었던 것
        }

        public override void Delete()
        {
            // 총알 삭제 구문 작성
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
            // 총알 삭제 구문 작성
        }

        public override void Fire()
        {
            _bullets.Arrow();
        }
    }
    // 이후 무기 추가될수록 추가 작성 할거임
}