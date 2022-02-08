using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Server.VO;
using Server.Core;

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
            BufferHandler.Instance.Add("joinroom", data => {
                UserDataVO playerData = UserManager.Instance.GetPlayerData();
                RoomVO vo = JsonUtility.FromJson<RoomVO>(data);

                if(vo.id == playerData.id) {
                    playerData.roomid = vo.roomid;
                    Debug.Log("Connected to " + playerData.roomid);
                    join.Set();
                }
            });

            BufferHandler.Instance.Add("leaveroom", data => {
                UserDataVO playerData = UserManager.Instance.GetPlayerData();
                RoomVO vo = JsonUtility.FromJson<RoomVO>(data);

                if(vo.id == playerData.id) {
                    playerData.roomid = -1;
                    leave.Set();
                }
            });

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