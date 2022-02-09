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
        public int damage;
        public int ownerId;
        public BulletType bulletType;

        public BulletFireVO(Vector2 firePos, Vector2 dir, float bulletSpeed, int damage, int ownerId, BulletType bulletType)
        {
            this.firePos = firePos;
            this.dir = dir;
            this.bulletSpeed = bulletSpeed;
            this.damage = damage;
            this.ownerId = ownerId;
            this.bulletType = bulletType;
        }
    }
}