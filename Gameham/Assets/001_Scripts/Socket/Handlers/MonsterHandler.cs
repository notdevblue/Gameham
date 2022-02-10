using Server.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHandler : MonoBehaviour
{
    private void Awake()
    {
        BufferHandler.Instance.Add("Monster", data =>
        {
            Debug.Log(data);
        });
    }
}
