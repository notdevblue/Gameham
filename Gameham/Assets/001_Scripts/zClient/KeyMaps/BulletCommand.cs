using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Commands
{
    abstract public class BulletCommand
    {
        abstract public float fireDelay { get; }
        abstract public float bulletSpeed { get; }
        abstract public int damage { get; }

        abstract public void SendFire(); // �Ѿ��� �߻��Ѵٰ� �������� �˷��ִ� �Լ�
        abstract public void RealFire(); // ������ �浹 �� �� �ִ� �Ѿ��� �߻��ϴ� �Լ�
        abstract public void EffectFire(); // �浹���� ���ϰ� �����ִ� �뵵�� �Ѿ��� �߻��ϴ� �Լ�
        abstract public void Delete(); // ����
    }
}
