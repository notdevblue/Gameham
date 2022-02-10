using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Bullets
{
    public interface IBullets
    {
        public void Test(); // Test 무기가 발사할 때 호출 될거임
        public void Arrow(float bulletSpeed, float bulletLifeTime, int damage, int bulletCount);
        public void LightBomb(float bulletSpeed, float bulletLifeTime, int damage, int bulletCount);
        // 이후 무기 추가 될시 추가 작성하면 댐
    }
}