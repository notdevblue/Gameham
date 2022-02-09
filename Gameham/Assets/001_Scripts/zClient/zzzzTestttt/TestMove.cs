using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �׳� �׽�Ʈ������ �����̴� ��ũ��Ʈ �ۼ��Ѱ�
/// </summary>
public class TestMove : MonoBehaviour
{
    public Vector2 moveDir = Vector3.right;

    private void Update()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0) * Time.deltaTime * 5;

        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }
    }
}
