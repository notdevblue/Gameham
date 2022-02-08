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
                // 방향과 데미지, 탄속, 발사한 주인의 값을 받아야 함
                // 받게 된다면 위의 값을 적용한 탄을 가져와서 발사해야함
                // 만약 모든 플레이어가 똑같은 값을 받고 똑같은 탄을 발사하면 문제가 생기기에
                // 총알 마다 발사한 주인을 알 수 있도록 그 값도 받도록 함
            });
        }
    }

}