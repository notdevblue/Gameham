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
        [Header("탄알들 프리팹")]
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
                    // 컬라이더가 있는 총알 발사
                }
                else
                {
                    // 컬라이더가 없는 총알 발사
                }
            });
        }
    }

}