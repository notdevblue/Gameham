using UnityEngine;
using UnityEngine.UI;
using Server.Core;
using Server.VO;


namespace Objects.UI
{
    public class ConnectButton : MonoBehaviour
    {
        [SerializeField] Button _btnConnect;
        [SerializeField] Text _roomName;
        [SerializeField] Text _userCount;
        int _connectTo = -1;


        public void Init(int connectTo, int userCount, string name, bool isPlaying)
        {
            _connectTo = connectTo;
            this._roomName.text = name;
            this._userCount.text = $"{userCount}/2";

            _btnConnect.onClick.RemoveAllListeners();

            if(isPlaying) {
                _btnConnect.interactable = false;
                return;
            }

            _btnConnect.onClick.AddListener(() => {
                string payload = JsonUtility.ToJson(new RoomVO(_connectTo, UserManager.Instance.GetPlayerData().id));
                SocketCore.Instance.Send(new DataVO("joinroom", payload), RequestType.JoinRoom);
            });
        }


    }
}