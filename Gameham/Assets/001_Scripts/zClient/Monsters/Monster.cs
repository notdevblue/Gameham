using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public float colDamage = 1f;
    public float moveSpeed = 1f;
    public int aggroPlayerId = -1;

    public virtual void Move()
    {
        // ¿Ãµø
    }
}
