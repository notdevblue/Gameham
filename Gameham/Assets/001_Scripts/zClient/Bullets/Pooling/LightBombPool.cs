using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Bullets.Pool
{
    public class LightBombPool : BulletPool
    {
        Animator anim;
        private void Awake()
        {
            anim = GetComponent<Animator>();
        }
        public override void Init(Vector2 dir, int damage, float bulletSpeed, float bulletLifeTime)
        {
            this.dir = dir;
            this.damage = damage;
            this.bulletSpeed = bulletSpeed;
            this.bulletLifeTime = bulletLifeTime;

            isFired = true;
        }

        protected override void Update()
        {
            base.Update();

            if (bulletLifeTime < 0.3f && isFired)
            {
                bulletSpeed = 0f;
                anim.SetBool("isBoom", true);
            }
            if (!isFired && anim.GetBool("isBoom"))
            {
                anim.SetBool("isBoom", false);
            }
        }

        /// <summary>
        /// �ð� ���� ���� �ٷ� �Ͷ߸��� �Լ�
        /// </summary>
        public void Boom()
        {
            bulletSpeed = 0f;
            StartCoroutine(BoomCo());
        }

        IEnumerator BoomCo()
        {
            anim.SetBool("isBoom", true);
            yield return new WaitForSeconds(0.3f);
            anim.SetBool("isBoom", true);
        }
    }
}

