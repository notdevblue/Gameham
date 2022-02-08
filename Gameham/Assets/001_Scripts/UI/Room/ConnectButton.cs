using UnityEngine;
using UnityEngine.UI;
using Server.Core;
using Server.VO;


namespace Server.UI
{
    public class ConnectButton : MonoBehaviour
    {
        [SerializeField] Button _btnConnect;
        [SerializeField] Text _roomName;
        [SerializeField] Text _userCount;
        int _connectTo = -1;


        public void Init(int connectTo, int userCount)
        {
            _connectTo = connectTo;
            this._roomName.text = "임시 방 이름";
            this._userCount.text = $"{userCount}/2";

            _btnConnect.onClick.RemoveAllListeners();
            _btnConnect.onClick.AddListener(() => {
                string payload = JsonUtility.ToJson(new RoomVO(_connectTo, UserManager.Instance.GetPlayerData().id));
                SocketCore.Instance.Send(new DataVO("joinroom", payload));
            });
        }


    }
}