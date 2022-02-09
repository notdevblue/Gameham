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

            StartShotBullet(); // 계속 반복해서 뭔갈 발사하는 함수
            Handler();
        }

        private void StartShotBullet()
        {
            foreach (BulletCommand command in _bulletDictionary.Values)
            {
                StartCoroutine(FireCoroutine(command));
            }
        }

        IEnumerator FireCoroutine(BulletCommand command)
        {
            while (true)
            {
                command.SendFire();
                yield return new WaitForSeconds(command.fireDelay);
            }
        }

        private void Handler()
        {
            BufferHandler.Instance.Add("bulletFire", data =>
            {
                BulletFireVO vo = JsonUtility.FromJson<BulletFireVO>(data);
                
                if(UserManager.Instance.GetPlayerData().id.CompareTo(vo.ownerId) == 0)
                {
                    // 컬라이더가 있는 총알 발사
                    _bulletDictionary[vo.bulletType].RealFire();
                }
                else
                {
                    // 컬라이더가 없는 총알 발사
                    _bulletDictionary[vo.bulletType].EffectFire();
                }
            });
        }
    }

}