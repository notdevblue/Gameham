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

        public override float fireDelay => -1;
        public override float bulletSpeed => -1;
        public override int damage => -1;

        public override void Delete()
        {
            // 총알 삭제 구문 작성
        }

        public override void SendFire()
        {
            // 총알을 쏜다고 서버에게 전달
        }

        public override void RealFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed)
        {
            // 총알 소환
        }

        public override void EffectFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed)
        {
            // 보여주기용 총알 소환
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
            // 총알 삭제 구문 작성
        }
        public override void SendFire()
        {
            _bullets.Arrow(bulletSpeed, damage);
        }
        public override void RealFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed) // 방향, 속도, 데미지
        {
            // 총알 발사하는 코드 작성함
            ArrowPool pool = PoolManager.GetItem<ArrowPool>(_arrowPrefab);
            
            pool.gameObject.AddComponent<BoxCollider2D>();
            pool.transform.position = firePos;
            pool.Init(fireDir, damage, bulletSpeed);
        }

        public override void EffectFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed) // 방향, 속도, 데미지
        {
            // 보여주기용 총알 발사하는 코드 작성할거임
            ArrowPool pool = PoolManager.GetItem<ArrowPool>(_arrowPrefab);

            pool.transform.position = firePos;
            pool.Init(fireDir, damage, bulletSpeed);
        }
    }
    // 이후 무기 추가될수록 추가 작성 할거임
}