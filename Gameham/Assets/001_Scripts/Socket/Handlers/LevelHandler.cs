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

        [SerializeField] private Transform ownerLevelUpPanel;
        [SerializeField] private Transform otherLevelUpPanel;

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

                    if (clientBase.ID.CompareTo(vo.id) == 0)
                    {
                        // ���⸦ ������ ���� ����ڶ�� ���̱⿡ �������� ������ �� �ִ� â�� �����
                        ownerLevelUpPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        // ���⸦ ������ �������� ����ڰ� ���� �ƴ϶�� ���̹Ƿ� �ٸ��� �����
                        otherLevelUpPanel.gameObject.SetActive(true);
                    }
                });
            });

            BufferHandler.Instance.Add("levelUpSelected", data =>
            {
                threadQueue.Enqueue(() =>
                {
                    // ���� ���� Ǯ��
                    GameManager.Instance.DePause();


                    ownerLevelUpPanel.gameObject.SetActive(false);
                    otherLevelUpPanel.gameObject.SetActive(false);
                });
            });
        }
    }
}