using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Bullets
{
    public interface IBullets
    {
        public void Test(); // Test ���Ⱑ �߻��� �� ȣ�� �ɰ���
        public void Arrow(float bulletSpeed, float bulletLifeTime, int damage);
        // ���� ���� �߰� �ɽ� �߰� �ۼ��ϸ� ��
    }
}