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
        private ClientBase _clientBase;
        private TestMove _testMove;

        private void Awake()
        {
            _clientBase = GetComponent<ClientBase>();
            _testMove = GetComponent<TestMove>();
        }

        void Send(Vector2 dir, float bulletSpeed, float bulletLifeTime, int damage, int ownerId, BulletType bulletType)
        {
            string payload = JsonUtility.ToJson(new BulletFireVO(_clientBase.transform.position, dir, bulletSpeed, bulletLifeTime, damage, ownerId, bulletType));
            SocketCore.Instance.Send(new DataVO("bulletFire", payload));
        }

        public void Test()
        {
            // Test 용 무기 발사 구문 작성
        }

        public void Arrow(float bulletSpeed, float bulletLifeTime, int damage)
        {
            // 여기서 보낼때 여러 효과들을 적용 한뒤 보내주어야 함
            Send(_testMove.moveDir, bulletSpeed, bulletLifeTime, damage, _clientBase.ID, BulletType.Arrow);
        }
    }

}