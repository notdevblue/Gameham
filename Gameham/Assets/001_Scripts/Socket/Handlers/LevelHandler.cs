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
                    // 게임 정지
                    GameManager.Instance.Pause();

                    LevelUpVO vo = JsonUtility.FromJson<LevelUpVO>(data);

                    Debug.Log("id:" + vo.id + "가 " + vo.level + "로 레벨업함");

                    if (clientBase.ID.CompareTo(vo.id) == 0)
                    {
                        // 여기를 들어오면 내가 당사자라는 것이기에 아이템을 선택할 수 있는 창을 띄워줌
                        ownerLevelUpPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        // 여기를 들어오면 레벨업한 당사자가 내가 아니라는 말이므로 다른걸 띄워줌
                        otherLevelUpPanel.gameObject.SetActive(true);
                    }
                });
            });

            BufferHandler.Instance.Add("levelUpSelected", data =>
            {
                threadQueue.Enqueue(() =>
                {
                    // 게임 정지 풀기
                    GameManager.Instance.DePause();


                    ownerLevelUpPanel.gameObject.SetActive(false);
                    otherLevelUpPanel.gameObject.SetActive(false);
                });
            });
        }
    }
}