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
                // Send(�ٶ󺸴� ����, ���ǵ�, ������, �߻�ü�� ����, _clientBase.ID);
                // yield return ���� ��Ÿ��;
            }
        }

        void Send(Vector2 dir, float bulletSpeed, int damage, BulletType bulletType, int ownerId)
        {
            string payload = JsonUtility.ToJson(new BulletFireVO(dir, bulletSpeed, damage, bulletType, ownerId));
            SocketCore.Instance.Send(new DataVO("bulletFire", payload));
        }
    }

}