using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBeetle : Monster
{
    public override float colDamage => 2;
    public override float moveSpeed => 1;

    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        // ���⼭ ��׷� �� �÷��̾�� �ڽ��� ���⺤�͸� ���ϰ� �������� ����ؼ� ���ư�
        // ���߿� ����
    }
}
