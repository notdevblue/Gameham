using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Bullets.Pool
{
    public abstract class BulletPool : MonoBehaviour
    {
        // Ǯ���� �ϱ����� MonoBehaviour�� �پ��ִ� ��ũ��Ʈ
        protected Vector3 dir;
        protected int damage;
        protected float bulletSpeed;

        protected bool isFired = false;
        protected bool isInfinityPierce = false;

        protected float bulletLifeTime = -1f;

        protected int pierceCount;

        public virtual void Init(Vector2 dir, int damage, float bulletSpeed, float bulletLifeTime, int pierceCount)
        {
            this.dir = dir;
            this.damage = damage;
            this.bulletSpeed = bulletSpeed;
            this.bulletLifeTime = bulletLifeTime;
            this.pierceCount = pierceCount;

            isFired = true;
        }

        protected virtual void Update()
        {
            if (isFired)
            {
                transform.position += dir * Time.deltaTime * bulletSpeed;
                bulletLifeTime -= Time.deltaTime;

                if (bulletLifeTime <= 0f)
                {
                    gameObject.SetActive(false);
                    isFired = false;
                }
            }
        }

        public virtual void Pierce()
        {
            if(isInfinityPierce)
            {
                return;
            }
            else
            {
                pierceCount--;

                if(pierceCount == 0)
                {
                    // ����ü ����
                    this.bulletLifeTime = 0f;
                    gameObject.SetActive(false);
                    isFired = false;
                }
            }
        }
    }

}
