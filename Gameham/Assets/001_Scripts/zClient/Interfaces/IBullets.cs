using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Bullets
{
    public interface IBullets
    {
        public void Test(); // Test ���Ⱑ �߻��� �� ȣ�� �ɰ���
        public void Arrow(float bulletSpeed, float bulletLifeTime, int damage, int bulletCount, int pierceCount);
        public void LightBomb(float bulletSpeed, float bulletLifeTime, int damage, int bulletCount, int pierceCount);
        public void MagicBall(float bulletSpeed, float bulletLifeTime, int damage, int bulletCount, int pierceCount);
        public void Landmine(float bulletSpeed, float bulletLifeTime, int damage, int bulletCount, int pierceCount);
        // ���� ���� �߰� �ɽ� �߰� �ۼ��ϸ� ��
    }
}