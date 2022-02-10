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

        public override void SendFire()
        {
            // �Ѿ��� ��ٰ� �������� ����
        }

        public override void RealFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed, float bulletLifeTime, int pierceCount)
        {
            // �Ѿ� ��ȯ
        }

        public override void EffectFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed, float bulletLifeTime, int pierceCount)
        {
            // �����ֱ�� �Ѿ� ��ȯ
        }

        public override void GetItem()
        {
            // isHaving�� true�� ����� �뵵 - �������� ������� ȣ���
        }

        public override void LevelUp()
        {
            // �������ϸ� ȣ��
        }

        public override int GetLevel()
        {
            // ������ ������ ����
            return -1;
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
            level = 8;

            isHaving = true;

            fireDelays = new float[8] { 0.5f, 0.5f, 0.45f, 0.45f, 0.4f, 0.35f, 0.3f, 0.25f };
            bulletSpeeds = new float[8] { 10, 10, 10, 10, 10, 10, 10, 10 };
            bulletLifeTimes = new float[8] { 5, 5, 5, 5, 5, 5, 5, 5 };
            damages = new int[8] { 4, 5, 6, 6, 7, 8, 8, 9 };
            bulletCounts = new int[8] { 1,1, 2, 2, 2, 2, 3, 3 };
            pierceCounts = new int[8] { 1, 1, 1, 2, 2, 2, 2, 2 };
        }

        public override void EffectFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed, float bulletLifeTime, int pierceCount) // ����, �ӵ�, ������
        {
            // �����ֱ�� �Ѿ� �߻��ϴ� �ڵ� �ۼ��Ұ���
            ArrowPool pool = PoolManager.GetItem<ArrowPool>(_arrowPrefab);

            pool.GetComponent<BoxCollider2D>().enabled = false;

            pool.transform.position = firePos;
            pool.Init(fireDir, damage, bulletSpeed, bulletLifeTime, pierceCount);
            pool.transform.rotation = Quaternion.Euler(0, 0, Vector2.Angle(Vector2.right, fireDir) * (fireDir.y >= 0 ? 1 : -1));

        }

        public override void GetItem()
        {
            isHaving = true;
        }

        public override int GetLevel()
        {
            return level - 1;
        }

        public override void LevelUp()
        {
            level++;

            // ���� ���
        }

        public override void RealFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed, float bulletLifeTime, int pierceCount) // ����, �ӵ�, ������
        {
            // �Ѿ� �߻��ϴ� �ڵ� �ۼ���
            ArrowPool pool = PoolManager.GetItem<ArrowPool>(_arrowPrefab);

            pool.GetComponent<BoxCollider2D>().enabled = true;

            pool.transform.position = firePos;
            pool.Init(fireDir, damage, bulletSpeed, bulletLifeTime, pierceCount);
            pool.transform.rotation = Quaternion.Euler(0, 0, Vector2.Angle(Vector2.right, fireDir) * (fireDir.y >= 0 ? 1 : -1));
        }
        public override void SendFire()
        {
            _bullets.Arrow(bulletSpeeds[GetLevel()], bulletLifeTimes[GetLevel()], damages[GetLevel()], bulletCounts[GetLevel()], pierceCounts[GetLevel()]);
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

            isHaving = false;

            fireDelays = new float[8] { 3, 3, 2.6f, 2.6f, 2.2f, 2f, 1.8f, 1.5f };
            bulletSpeeds = new float[8] { 1, 1, 1, 1, 1, 1, 1.2f, 1.3f };
            bulletLifeTimes = new float[8] { 4, 4, 4, 4, 4, 4, 4, 4 };
            damages = new int[8] { 12, 13, 14, 15, 16, 16, 17, 20 };
            bulletCounts = new int[8] { 1, 1, 2, 2, 2, 3, 3, 4 };
            pierceCounts = new int[8] { 1, 1, 1, 1, 1, 1, 1, 1 };
        }

        public override void EffectFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed, float bulletLifeTime, int pierceCount)
        {
            // �Ѿ� �߻��ϴ� �ڵ� �ۼ���
            LightBombPool pool = PoolManager.GetItem<LightBombPool>(_lightBombPrefab);

            pool.GetComponent<BoxCollider2D>().enabled = false;

            pool.transform.position = firePos;
            pool.Init(fireDir, damage, bulletSpeed, bulletLifeTime, pierceCount);
        }

        public override void GetItem()
        {
            isHaving = true;
        }
        public override int GetLevel()
        {
            return level - 1;
        }

        public override void LevelUp()
        {
            level++;

            // ���� ���
        }

        public override void RealFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed, float bulletLifeTime, int pierceCount)
        {
            // �Ѿ� �߻��ϴ� �ڵ� �ۼ���
            LightBombPool pool = PoolManager.GetItem<LightBombPool>(_lightBombPrefab);

            pool.GetComponent<BoxCollider2D>().enabled = true;

            pool.transform.position = firePos;
            pool.Init(fireDir, damage, bulletSpeed, bulletLifeTime, pierceCount);
        }

        public override void SendFire()
        {
            _bullets.LightBomb(bulletSpeeds[GetLevel()], bulletLifeTimes[GetLevel()], damages[GetLevel()], bulletCounts[GetLevel()], pierceCounts[GetLevel()]);
        }
    }

    public class MagicBallBullet : BulletCommand
    {
        IBullets _bullets;
        GameObject _magicBallPrefab;

        public MagicBallBullet(IBullets bullets, GameObject magicBallPrefab, Transform parent)
        {
            _bullets = bullets;
            _magicBallPrefab = magicBallPrefab;

            PoolManager.CreatePool<MagicBallPool>(_magicBallPrefab, parent, 100);
            level = 1;

            isHaving = false;

            fireDelays = new float[8] { 4f, 3.9f, 3.8f, 3.7f, 3.6f, 3.5f, 3.3f, 3f };
            bulletSpeeds = new float[8] { 3, 3, 3, 3.3f, 3.3f, 3.3f, 3.3f, 3.5f };
            bulletLifeTimes = new float[8] { 6, 6, 6, 6, 6, 6, 6, 6 };
            damages = new int[8] { 5, 6, 6, 6, 7, 7, 8, 9 };
            bulletCounts = new int[8] { 1, 1, 2, 2, 3, 4, 5, 6 };
            pierceCounts = new int[8] { 100, 100, 100, 100, 100, 100, 100, 100 };
        }

        public override void EffectFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed, float bulletLifeTime, int pierceCount)
        {
            // �Ѿ� �߻��ϴ� �ڵ� �ۼ���
            MagicBallPool pool = PoolManager.GetItem<MagicBallPool>(_magicBallPrefab);

            pool.GetComponent<BoxCollider2D>().enabled = false;

            pool.transform.position = firePos;
            pool.Init(fireDir, damage, bulletSpeed, bulletLifeTime, pierceCount);
            pool.transform.rotation = Quaternion.Euler(0, 0, Vector2.Angle(Vector2.right, fireDir) * (fireDir.y >= 0 ? 1 : -1));
        }

        public override void GetItem()
        {
            isHaving = true;
        }
        public override int GetLevel()
        {
            return level - 1;
        }
        public override void LevelUp()
        {
            level++;

            // ���� ���
        }

        public override void RealFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed, float bulletLifeTime, int pierceCount)
        {
            // �Ѿ� �߻��ϴ� �ڵ� �ۼ���
            MagicBallPool pool = PoolManager.GetItem<MagicBallPool>(_magicBallPrefab);

            pool.GetComponent<BoxCollider2D>().enabled = true;

            pool.transform.position = firePos;
            pool.Init(fireDir, damage, bulletSpeed, bulletLifeTime, pierceCount);
            pool.transform.rotation = Quaternion.Euler(0, 0, Vector2.Angle(Vector2.right, fireDir) * (fireDir.y >= 0 ? 1 : -1));
        }

        public override void SendFire()
        {
            _bullets.MagicBall(bulletSpeeds[GetLevel()], bulletLifeTimes[GetLevel()], damages[GetLevel()], bulletCounts[GetLevel()], pierceCounts[GetLevel()]);
        }
    }

    public class LandmineBullet : BulletCommand
    {
        IBullets _bullets;
        GameObject _landminePrefab;

        public LandmineBullet(IBullets bullets, GameObject landminePrefab, Transform parent)
        {
            _bullets = bullets;
            _landminePrefab = landminePrefab;

            PoolManager.CreatePool<LandminePool>(_landminePrefab, parent, 100);
            level = 1;

            isHaving = false;

            fireDelays = new float[8] { 6, 6, 6, 5.5f, 5f, 4f, 3.5f, 3f };
            bulletSpeeds = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            bulletLifeTimes = new float[8] { 10, 11, 11, 12, 13, 14, 15, 15 };
            damages = new int[8] { 15, 16, 17, 17, 17, 18, 19, 22 };
            bulletCounts = new int[8] { 1, 1, 2, 2, 3, 3, 4, 5 };
            pierceCounts = new int[8] { 1, 1, 1, 1, 1, 1, 1, 1 };
        }

        public override void EffectFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed, float bulletLifeTime, int pierceCount)
        {
            // �Ѿ� �߻��ϴ� �ڵ� �ۼ���
            LandminePool pool = PoolManager.GetItem<LandminePool>(_landminePrefab);

            pool.GetComponent<BoxCollider2D>().enabled = false;

            pool.transform.position = firePos;
            pool.Init(fireDir, damage, bulletSpeed, bulletLifeTime, pierceCount);
        }

        public override void GetItem()
        {
            isHaving = true;
        }
        public override int GetLevel()
        {
            return level - 1;
        }
        public override void LevelUp()
        {
            level++;

            // ���� ���
        }

        public override void RealFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed, float bulletLifeTime, int pierceCount)
        {
            // �Ѿ� �߻��ϴ� �ڵ� �ۼ���
            LandminePool pool = PoolManager.GetItem<LandminePool>(_landminePrefab);

            pool.GetComponent<BoxCollider2D>().enabled = true;

            pool.transform.position = firePos;
            pool.Init(fireDir, damage, bulletSpeed, bulletLifeTime, pierceCount);
        }

        public override void SendFire()
        {
            _bullets.Landmine(bulletSpeeds[GetLevel()], bulletLifeTimes[GetLevel()], damages[GetLevel()], bulletCounts[GetLevel()], pierceCounts[GetLevel()]);
        }
    }
    // ���� ���� �߰��ɼ��� �߰� �ۼ� �Ұ���
}