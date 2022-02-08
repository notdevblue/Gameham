using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Server.Core;
using Server.VO;
using Server.Client.Core;
using Commands;
using Player.Bullets;
using Player.Bullets.Remote;

namespace Server.Handler
{
    public class BulletFireHandler : MonoBehaviour
    {
        private Dictionary<BulletType, BulletCommand> _bulletDictionary = new Dictionary<BulletType, BulletCommand>();
        private RemoteBullet _remoteBullet;

        [SerializeField] private ClientBase _clientbase;

        [SerializeField] private Transform bulletParent;
        [Header("ź�˵� ������")]
        [SerializeField] private GameObject arrowPrefab;

        private void Awake()
        {
            _remoteBullet = FindObjectOfType<RemoteBullet>();

            if (_remoteBullet == null)
            {
                // Fatal
            }

            _bulletDictionary.Add(BulletType.Test, new TestBullet(_remoteBullet));
            _bulletDictionary.Add(BulletType.Arrow, new ArrowBullet(_remoteBullet, arrowPrefab, bulletParent));

            Handler();
        }

        private void Handler()
        {
            BufferHandler.Instance.Add("bulletFire", data =>
            {
                BulletFireVO vo = JsonUtility.FromJson<BulletFireVO>(data);

                if(_clientbase.ID.CompareTo(vo.ownerId) == 0)
                {
                    // �ö��̴��� �ִ� �Ѿ� �߻�
                }
                else
                {
                    // �ö��̴��� ���� �Ѿ� �߻�
                }
            });
        }
    }

}