using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public abstract float colDamage { get; }
    public abstract float moveSpeed { get; }

    public int aggroPlayerId = -1;

    public virtual void Move()
    {
        // ¿Ãµø
    }
}
