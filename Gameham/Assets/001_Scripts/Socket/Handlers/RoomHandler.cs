using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Server.VO;
using Server.Core;
using Objects.UI;

namespace Server.Handler
{
    public class RoomHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _roomPannel;
        [SerializeField] private GameObject _roomInsidePannel;

        Flag join = new Flag(false);
        Flag leave = new Flag(false);

        private void Awake()
        {
            BufferHandler.Instance.Add("response", data => {
                if(!SocketCore.Instance.IsType(RequestType.JoinRoom)) return; // 방 참가 요청이 아님

                UserDataVO playerData = UserManager.Instance.GetPlayerData();
                RoomIDVO vo = SocketCore.Instance.GetLastRequestPayload<RoomIDVO>();

                playerData.roomid = vo.roomid;
                join.Set();
            }, true);

            BufferHandler.Instance.Add("response", data => {
                if(!SocketCore.Instance.IsType(RequestType.JoinRoom)) return; // 방 퇴장 요청이 아님

                UserDataVO playerData = UserManager.Instance.GetPlayerData();
                playerData.roomid = -1;

                leave.Set();
            }, true);

            StartCoroutine(EnableInnerPannel());
            StartCoroutine(DisableInnerPannel());
        }

        IEnumerator EnableInnerPannel()
        {
            while(true)
            {
                yield return new WaitUntil(join.Get);
                _roomPannel.SetActive(false);
                _roomInsidePannel.SetActive(true);
                ReadyIcon.Instance.SetIcon(0);
            }
        }

        IEnumerator DisableInnerPannel()
        {
            while (true)
            {
                yield return new WaitUntil(leave.Get);
                _roomInsidePannel.SetActive(false);
                _roomPannel.SetActive(true);
            }
        }
    }
}