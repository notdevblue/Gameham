using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Commands
{
    abstract public class BulletCommand
    {
        abstract public float fireDelay { get; }
        abstract public float bulletSpeed { get; }
        abstract public float bulletLifeTime { get; }
        abstract public int damage { get; }

        public bool isHaving;

        public int level = 1;

        public int bulletCount = 1;

        abstract public void SendFire(); // 총알을 발사한다고 서버에게 알려주는 함수
        abstract public void RealFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed, float bulletLifeTime); // 실제로 충돌 할 수 있는 총알을 발사하는 함수
        abstract public void EffectFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed, float bulletLifeTime); // 충돌하지 못하고 보여주는 용도의 총알을 발사하는 함수
        abstract public void GetItem(); // 이 무기 또는 아이템을 얻을때 실행되는 함수
        abstract public void LevelUp(); // 레벨업 할 때 호출
    }
}
