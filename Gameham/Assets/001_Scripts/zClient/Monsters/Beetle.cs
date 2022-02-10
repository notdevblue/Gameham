using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle : Monster
{
    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        // 여기서 어그로 된 플레이어와 자신의 방향벡터를 구하고 그쪽으로 계속해서 나아감
        // 나중에 수정
    }
}
