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
        Arrow = 1,
        // 이후 무기가 추가될수록 작성될거임
    }
}

namespace Player.Bullets.Remote
{
    public class RemoteBullet : MonoBehaviour, IBullets
    {
        [SerializeField] ClientBase _clientBase;

        void Send(Vector2 dir, float bulletSpeed, int damage, BulletType bulletType, int ownerId)
        {
            string payload = JsonUtility.ToJson(new BulletFireVO(_clientBase.transform.position, dir, bulletSpeed, damage, ownerId, bulletType));
            SocketCore.Instance.Send(new DataVO("bulletFire", payload));
        }

        public void Test()
        {
            // Test 용 무기 발사 구문 작성
        }

        public void Arrow(float bulletSpped, int damage)
        {
            // 여기서 보낼때 여러 효과들을 적용 한뒤 보내주어야 함
            // Send(dir, bulletSpeed, damage, BulletType.Arrow, _clientBase.ID);
        }
    }

}