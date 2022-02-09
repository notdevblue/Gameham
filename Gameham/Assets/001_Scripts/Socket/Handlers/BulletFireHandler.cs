using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Server.Core;
using Server.VO;
using Server.Client.Core;
using Commands;
using Player.Bullets;
using Player.Bullets.Remote;
using System;

namespace Server.Handler
{
    public class BulletFireHandler : MonoBehaviour
    {
        private Dictionary<BulletType, BulletCommand> _bulletDictionary = new Dictionary<BulletType, BulletCommand>();
        private RemoteBullet _remoteBullet;

        private Queue<Action> fireQueue = new Queue<Action>(); // 유니티가 mainThread이외에는 리소스 건들지 말라해서 만든 큐

        [SerializeField] ClientBase _clientBase;

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

                if (_clientBase.ID.CompareTo(vo.ownerId) == 0)
                {
                    // 컬라이더가 있는 총알 발사
                    fireQueue.Enqueue(() =>
                    {
                        _bulletDictionary[vo.bulletType].RealFire(vo.firePos, vo.dir, vo.damage, vo.bulletSpeed, vo.bulletLifeTime);
                    });
                }
                else
                {
                    // 컬라이더가 없는 총알 발사
                    fireQueue.Enqueue(() =>
                    {
                        _bulletDictionary[vo.bulletType].EffectFire(vo.firePos, vo.dir, vo.damage, vo.bulletSpeed, vo.bulletLifeTime);
                    });
                }
            });
        }

        private void Update()
        {
            if(fireQueue.Count != 0)
            {
                fireQueue.Dequeue().Invoke();
            }
        }
    }

}