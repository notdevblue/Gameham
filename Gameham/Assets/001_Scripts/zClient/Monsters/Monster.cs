using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public float colDamage = 1f;
    //public float moveSpeed = 1f;
    //public int aggroPlayerId = -1;

    public virtual void OnDamage()
    {
        // hp 감소

        // 만약 hp가 0 이하라면 플레이어 사망 처리
    }

    public virtual void Move()
    {
        // 이동
    }
}
