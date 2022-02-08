using UnityEngine;
using UnityEngine.UI;
using Server.Core;
using Server.VO;

namespace Objects.UI
{
    public class QueryRoom : MonoBehaviour
    {
        [SerializeField] Button _btnQuery;


        private void Awake()
        {
            _btnQuery.onClick.AddListener(() => {
                SocketCore.Instance.Send(new DataVO("roomquery", ""));
            });
        }
    }
}