using UnityEngine;
using UnityEngine.UI;
using Server.Core;
using Server.VO;

namespace Objects.UI
{
    public class ExitRoom : MonoBehaviour
    {
        [SerializeField] Button _btnExit;


        private void Awake()
        {
            UserDataVO data = UserManager.Instance.GetPlayerData();

            _btnExit.onClick.AddListener(() => {
                string payload = JsonUtility.ToJson(new RoomVO(data.roomid, data.id));
                SocketCore.Instance.Send(new DataVO("leaveroom", payload));
            });
        }
    }
}