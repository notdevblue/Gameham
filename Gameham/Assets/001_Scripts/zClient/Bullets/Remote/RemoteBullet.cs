using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Server.Client.Core;
using Server.Core;
using Server.VO;
using Player.Bullets;

namespace Player.Bullets
{
    public enum BulletType
    {
        Test = -1,
    }
}

namespace Player.Bullets.Remote
{
    public class RemoteBullet : MonoBehaviour
    {
        [SerializeField] ClientBase _clientBase;

        private void Awake()
        {
            
        }

        IEnumerator TestWeapon()
        {
            while(true)
            {
                // Send(바라보는 방향, 스피드, 데미지, 발사체의 종류, _clientBase.ID);
                // yield return 무기 쿨타임;
            }
        }

        void Send(Vector2 dir, float bulletSpeed, int damage, BulletType bulletType, int ownerId)
        {
            string payload = JsonUtility.ToJson(new BulletFireVO(dir, bulletSpeed, damage, bulletType, ownerId));
            SocketCore.Instance.Send(new DataVO("bulletFire", payload));
        }
    }

}