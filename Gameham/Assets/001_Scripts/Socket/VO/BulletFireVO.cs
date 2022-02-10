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
        public Vector2 firePos;
        public Vector2 dir;
        public float bulletSpeed;
        public float bulletLifeTime;
        public int damage;
        public int ownerId;
        public int pierceCount;
        public BulletType bulletType;

        public BulletFireVO(Vector2 firePos, Vector2 dir, float bulletSpeed, float bulletLifeTime, int damage, int ownerId, int pierceCount, BulletType bulletType)
        {
            this.firePos = firePos;
            this.dir = dir;
            this.bulletSpeed = bulletSpeed;
            this.bulletLifeTime = bulletLifeTime;
            this.damage = damage;
            this.ownerId = ownerId;
            this.pierceCount = pierceCount;
            this.bulletType = bulletType;
        }
    }
}