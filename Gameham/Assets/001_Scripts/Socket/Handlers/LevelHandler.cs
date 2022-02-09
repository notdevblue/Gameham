using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Server.Core;
using Server.Client.Core;
using Server.VO;

namespace Server.Handler
{
    public class LevelHandler : MonoBehaviour
    {
        [SerializeField] private ClientBase clientBase;

        private ThreadQueue threadQueue;

        private void Awake()
        {
            threadQueue = new ThreadQueue(this);

            BufferHandler.Instance.Add("levelUp", data =>
            {
                threadQueue.Enqueue(() =>
                {
                    // ���� ����
                    GameManager.Instance.Pause();

                    LevelUpVO vo = JsonUtility.FromJson<LevelUpVO>(data);

                    Debug.Log("id:" + vo.id + "�� " + vo.level + "�� ��������");
                    // �������Ǹ� �������� ����ڰ� ���� �� ������ ��޷�����
                    if (clientBase.ID.CompareTo(vo.id) == 0)
                    {
                        // ���⸦ ������ ���� ����ڶ�� ���̱⿡
                        // ���� �� �� �ִ� �� ���ñ⸦ ��������
                    }
                });
            });

            BufferHandler.Instance.Add("levelUpSelected", data =>
            {
                threadQueue.Enqueue(() =>
                {
                    // ���� ���� Ǯ��
                    GameManager.Instance.DePause();
                });
            });
        }
    }
}