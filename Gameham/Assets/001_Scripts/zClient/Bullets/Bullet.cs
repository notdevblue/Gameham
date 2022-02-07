using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour, IBulletObject
{
    public int bulletId = -1;
    public float bulletSpeed = 0;
    public float bulletDamage = 0;

    private Vector2 bulletShotDir = Vector2.zero;

    public virtual void OnDamage(Monster monster)
    {
        // 몬스터의 체력이 bulletDamage 만큼 감소..
    }
}
