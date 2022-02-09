using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Bullets.Pool
{
    public class ArrowPool : MonoBehaviour
    {
        // Ǯ���� �ϱ����� MonoBehaviour�� �پ��ִ� ��ũ��Ʈ
        private Vector3 dir;
        private int damage;
        private float bulletSpeed;

        private bool isFired = false;

        public void Init(Vector2 dir, int damage, float bulletSpeed)
        {
            this.dir = dir;
            this.damage = damage;
            this.bulletSpeed = bulletSpeed;

            isFired = true;
        }

        private void Update()
        {
            if(isFired)
            {
                transform.position += dir * Time.deltaTime * bulletSpeed;
            }
        }
    }

}