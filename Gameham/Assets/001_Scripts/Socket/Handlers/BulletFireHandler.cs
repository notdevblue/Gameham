using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Server.Core;
using Server.VO;

namespace Server.Handler
{
    public class BulletFireHandler : MonoBehaviour
    {
        private void Awake()
        {
            BufferHandler.Instance.Add("bulletFire", data =>
            {
                // ����� ������, ź��, �߻��� ������ ���� �޾ƾ� ��
                // �ް� �ȴٸ� ���� ���� ������ ź�� �����ͼ� �߻��ؾ���
                // ���� ��� �÷��̾ �Ȱ��� ���� �ް� �Ȱ��� ź�� �߻��ϸ� ������ ����⿡
                // �Ѿ� ���� �߻��� ������ �� �� �ֵ��� �� ���� �޵��� ��
            });
        }
    }

}