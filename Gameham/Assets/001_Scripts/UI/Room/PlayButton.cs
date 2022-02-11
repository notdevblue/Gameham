using UnityEngine;
using UnityEngine.UI;
using Server.Core;
using Server.VO;

namespace Objects.UI
{
    public class PlayButton : MonoBehaviour
    {
        [SerializeField] Button _btnPlay;

        private void Awake()
        {
            _btnPlay.onClick.AddListener(() => {
                SocketCore.Instance.Send(new DataVO("start", ""));
            });
        }
    }
}