using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Bullets.Pool
{
    public class ArrowPool : BulletPool
    {
        public override void Init(Vector2 dir, int damage, float bulletSpeed, float bulletLifeTime)
        {
            this.dir = dir;
            this.damage = damage;
            this.bulletSpeed = bulletSpeed;
            this.bulletLifeTime = bulletLifeTime;

            isFired = true;
        }
    }

}