using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Server.Core;
using Server.VO;
using Commands;
using Player.Bullets;
using Player.Bullets.Remote;

namespace Server.Handler
{
    public class BulletFireHandler : MonoBehaviour
    {
        private Dictionary<BulletType, BulletCommand> _bulletDictionary = new Dictionary<BulletType, BulletCommand>();
        private RemoteBullet _remoteBullet;

        private void Awake()
        {
            _remoteBullet = FindObjectOfType<RemoteBullet>();

            if (_remoteBullet == null)
            {
                // Fatal
            }

            _bulletDictionary.Add(BulletType.Test, new TestBullet(_remoteBullet));

            Handlers();
        }

        private void Handlers()
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