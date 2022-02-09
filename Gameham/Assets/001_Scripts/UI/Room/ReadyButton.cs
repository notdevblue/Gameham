using UnityEngine;
using UnityEngine.UI;
using Server.Core;
using Server.VO;

namespace Objects.UI
{
    public class ReadyButton : MonoBehaviour
    {
        [SerializeField] Button _btnReady;

        private void Awake()
        {
            _btnReady.onClick.AddListener(() => {
                SocketCore.Instance.Send(new DataVO("ready", ""));
            });
        }
    }
}