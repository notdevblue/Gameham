using Server.Core;
using Server.VO;
using UnityEngine;

namespace Server.Handler
{
    public class ReadyHandler : MonoBehaviour
    {
        private void Awake()
        {
            BufferHandler.Instance.Add("ready", data => {
                ReadyVO vo = JsonUtility.FromJson<ReadyVO>(data);

                UserManager.Instance.GetUser(vo.id).ready = vo.status;
            });
        }
    }
}