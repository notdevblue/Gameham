using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public int bulletId = -1;
    public float bulletSpeed = 0;
    public float bulletDamage = 0;

    private Vector2 bulletShotDir = Vector2.zero;


}
