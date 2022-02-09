using UnityEngine;
using Server.Core;
using Server.VO;
using Server.Client.Core;

namespace Server.Handler
{
    /// <summary>
    /// 서버로부터 전달받는 기본 데이터 저장 용
    /// </summary>
    public class DataInitHandler : MonoBehaviour
    {
        private void Awake()
        {
            BufferHandler.Instance.Add("init", data => {
                InitVO vo = JsonUtility.FromJson<InitVO>(data);
                UserManager.Instance.SetPlayerData(vo.id, new UserDataVO(vo.id));
            });
        }
    }
}