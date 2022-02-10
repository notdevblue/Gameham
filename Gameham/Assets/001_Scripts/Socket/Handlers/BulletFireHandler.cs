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
using Player.Passive.Passives;
using Player.Passive;

namespace Server.Handler
{
    public class BulletFireHandler : MonoBehaviour
    {
        private Dictionary<BulletType, BulletCommand> _bulletDictionary = new Dictionary<BulletType, BulletCommand>();
        private RemoteBullet _remoteBullet;
        private ThreadQueue _thraedQueue;

        [SerializeField] ClientBase _clientBase;

        [SerializeField] private Transform bulletParent;
        [Header("ź�˵� ������")]
        [SerializeField] private GameObject arrowPrefab;
        [SerializeField] private GameObject lightBombPrefab;
        [SerializeField] private GameObject magicBallPrefab;
        [SerializeField] private GameObject landminePrefab;

        private void Awake()
        {
            _remoteBullet = FindObjectOfType<RemoteBullet>();
            _thraedQueue = new ThreadQueue(this);

            if (_remoteBullet == null)
            {
                // Fatal
            }

            _bulletDictionary.Add(BulletType.Test, new TestBullet(_remoteBullet));
            _bulletDictionary.Add(BulletType.Arrow, new ArrowBullet(_remoteBullet, arrowPrefab, bulletParent));
            _bulletDictionary.Add(BulletType.LightBomb, new LightBombBullet(_remoteBullet, lightBombPrefab, bulletParent));
            _bulletDictionary.Add(BulletType.MagicBall, new MagicBallBullet(_remoteBullet, magicBallPrefab, bulletParent));
            _bulletDictionary.Add(BulletType.Landmine, new LandmineBullet(_remoteBullet, landminePrefab, bulletParent));

            StartShotBullet(); // ��� �ݺ��ؼ� ���� �߻��ϴ� �Լ�
            Handler();
        }

        private void StartShotBullet()
        {
            foreach (BulletCommand command in _bulletDictionary.Values)
            {
                if(command.isHaving)
                {
                    StartCoroutine(FireCoroutine(command));
                }
            }
        }

        IEnumerator FireCoroutine(BulletCommand command)
        {
            while (true)
            {
                command.SendFire();
                yield return new WaitForSeconds(
                    command.fireDelays[command.GetLevel()] - 
                    (command.fireDelays[command.GetLevel()] * (Passives.Instance.GetValue(PassiveType.ShotCoolTime) / 100)));
            }
        }

        private void Handler()
        {
            BufferHandler.Instance.Add("bulletFire", data =>
            {
                BulletFireVO vo = JsonUtility.FromJson<BulletFireVO>(data);

                if (_clientBase.ID.CompareTo(vo.ownerId) == 0)
                {
                    // �ö��̴��� �ִ� �Ѿ� �߻�
                    _thraedQueue.Enqueue(() =>
                    {
                        _bulletDictionary[vo.bulletType].RealFire(vo.firePos, vo.dir, vo.damage, vo.bulletSpeed, vo.bulletLifeTime, vo.pierceCount);
                    });
                }
                else
                {
                    // �ö��̴��� ���� �Ѿ� �߻�
                    _thraedQueue.Enqueue(() =>
                    {
                        _bulletDictionary[vo.bulletType].EffectFire(vo.firePos, vo.dir, vo.damage, vo.bulletSpeed, vo.bulletLifeTime, vo.pierceCount);
                    });
                }
            });
        }
    }

}