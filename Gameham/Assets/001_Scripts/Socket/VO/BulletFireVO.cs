using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Player.Bullets;

namespace Server.VO
{
    [Serializable]
    public class BulletFireVO
    {
        public Vector2 dir;
        public float bulletSpeed;
        public int damage;
        public BulletType bulletType;
        public int ownerId;

        public BulletFireVO(Vector2 dir, float bulletSpeed, int damage, BulletType bulletType, int ownerId)
        {
            this.dir = dir;
            this.bulletSpeed = bulletSpeed;
            this.damage = damage;
            this.bulletType = bulletType;
            this.ownerId = ownerId;
        }
    }
}