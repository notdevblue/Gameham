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
        public override float bulletLifeTime => -1;
        public override int damage => -1;

        public override void SendFire()
        {
            // 총알을 쏜다고 서버에게 전달
        }

        public override void RealFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed, float bulletLifeTime)
        {
            // 총알 소환
        }

        public override void EffectFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed, float bulletLifeTime)
        {
            // 보여주기용 총알 소환
        }

        public override void GetItem()
        {
            // isHaving을 true로 만드는 용도 - 아이템을 얻었을때 호출됨
        }

        public override void LevelUp()
        {
            // 레벨업하면 호출
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
            level = 1;
        }

        public override float fireDelay => 0.05f;
        public override float bulletSpeed => 10;
        public override float bulletLifeTime => 5;
        public override int damage => 4;


        public override void EffectFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed, float bulletLifeTime) // 방향, 속도, 데미지
        {
            // 보여주기용 총알 발사하는 코드 작성할거임
            ArrowPool pool = PoolManager.GetItem<ArrowPool>(_arrowPrefab);

            pool.GetComponent<BoxCollider2D>().enabled = false;

            pool.transform.position = firePos;
            pool.Init(fireDir, damage, bulletSpeed, bulletLifeTime);
            pool.transform.rotation = Quaternion.Euler(0, 0, Vector2.Angle(Vector2.right, fireDir) * (fireDir.y >= 0 ? 1 : -1));

        }

        public override void GetItem()
        {
            isHaving = true;
        }

        public override void LevelUp()
        {
            level++;

            // 스텟 상승
        }

        public override void RealFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed, float bulletLifeTime) // 방향, 속도, 데미지
        {
            // 총알 발사하는 코드 작성함
            ArrowPool pool = PoolManager.GetItem<ArrowPool>(_arrowPrefab);

            pool.GetComponent<BoxCollider2D>().enabled = true;

            pool.transform.position = firePos;
            pool.Init(fireDir, damage, bulletSpeed, bulletLifeTime);
            pool.transform.rotation = Quaternion.Euler(0, 0, Vector2.Angle(Vector2.right, fireDir) * (fireDir.y >= 0 ? 1 : -1));
        }
        public override void SendFire()
        {
            _bullets.Arrow(bulletSpeed, bulletLifeTime, damage, bulletCount);
        }

    }

    public class LightBombBullet : BulletCommand
    {
        IBullets _bullets;
        GameObject _lightBombPrefab;

        public LightBombBullet(IBullets bullets, GameObject lightBombPrefab, Transform parent)
        {
            _bullets = bullets;
            _lightBombPrefab = lightBombPrefab;

            PoolManager.CreatePool<LightBombPool>(_lightBombPrefab, parent, 100);
            level = 1;
            bulletCount = 1;

            isHaving = true;
        }
        public override float fireDelay => 3f;

        public override float bulletSpeed => 1f;

        public override float bulletLifeTime => 4;

        public override int damage => 12;

        

        public override void EffectFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed, float bulletLifeTime)
        {
            // 총알 발사하는 코드 작성함
            LightBombPool pool = PoolManager.GetItem<LightBombPool>(_lightBombPrefab);

            pool.GetComponent<BoxCollider2D>().enabled = false;

            pool.transform.position = firePos;
            pool.Init(fireDir, damage, bulletSpeed, bulletLifeTime);
        }

        public override void GetItem()
        {
            isHaving = true;
        }

        public override void LevelUp()
        {
            level++;

            // 스텟 상승
        }

        public override void RealFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed, float bulletLifeTime)
        {
            // 총알 발사하는 코드 작성함
            LightBombPool pool = PoolManager.GetItem<LightBombPool>(_lightBombPrefab);

            pool.GetComponent<BoxCollider2D>().enabled = true;

            pool.transform.position = firePos;
            pool.Init(fireDir, damage, bulletSpeed, bulletLifeTime);
        }

        public override void SendFire()
        {
            _bullets.LightBomb(bulletSpeed, bulletLifeTime, damage, bulletCount);
        }
    }
    // 이후 무기 추가될수록 추가 작성 할거임
}