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
                    // 게임 정지
                    GameManager.Instance.Pause();

                    LevelUpVO vo = JsonUtility.FromJson<LevelUpVO>(data);

                    Debug.Log("id:" + vo.id + "가 " + vo.level + "로 레벨업함");
                    // 레벨업되며 레벨업한 당사자가 선택 할 때까지 기달려야함
                    if (clientBase.ID.CompareTo(vo.id) == 0)
                    {
                        // 여기를 들어오면 내가 당사자라는 것이기에
                        // 선택 할 수 있는 그 뭐시기를 띄워줘야함
                    }
                });
            });

            BufferHandler.Instance.Add("levelUpSelected", data =>
            {
                threadQueue.Enqueue(() =>
                {
                    // 게임 정지 풀기
                    GameManager.Instance.DePause();
                });
            });
        }
    }
}