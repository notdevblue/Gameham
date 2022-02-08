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
        private void Awake()
        {
            BufferHandler.Instance.Add("level", data =>
            {
            // 게임 정지
                GameManager.Instance.Pause();

                LevelVO vo = JsonUtility.FromJson<LevelVO>(data);

                // 레벨업되며 레벨업한 당사자가 선택 할 때까지 기달려야함
                if (clientBase.ID.CompareTo(vo.id) == 0)
                {
                    // 여기를 들어오면 내가 당사자라는 것이기에
                    // 선택 할 수 있는 그 뭐시기를 띄워줘야함
                }
            });
        }
    }
}