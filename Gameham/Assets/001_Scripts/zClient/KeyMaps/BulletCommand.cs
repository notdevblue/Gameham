using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Commands
{
    abstract public class BulletCommand
    {
        //abstract public float fireDelay { get; }
        //abstract public float bulletSpeed { get; }
        //abstract public float bulletLifeTime { get; }
        //abstract public int damage { get; }
        //abstract public int pierceCount { get; }

        public float[] fireDelays;
        public float[] bulletSpeeds;
        public float[] bulletLifeTimes;
        public int[] damages;
        public int[] bulletCounts;
        public int[] pierceCounts;


        public bool isHaving;

        protected int level = 1;

        abstract public void SendFire(); // �Ѿ��� �߻��Ѵٰ� �������� �˷��ִ� �Լ�
        abstract public void RealFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed, float bulletLifeTime, int pierceCount); // ������ �浹 �� �� �ִ� �Ѿ��� �߻��ϴ� �Լ�
        abstract public void EffectFire(Vector2 firePos, Vector2 fireDir, int damage, float bulletSpeed, float bulletLifeTime, int pierceCount); // �浹���� ���ϰ� �����ִ� �뵵�� �Ѿ��� �߻��ϴ� �Լ�
        abstract public void GetItem(); // �� ���� �Ǵ� �������� ������ ����Ǵ� �Լ�
        abstract public void LevelUp(); // ������ �� �� ȣ��
        abstract public int GetLevel();
    }
}
