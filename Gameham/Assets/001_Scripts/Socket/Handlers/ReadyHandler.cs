using System.Collections;
using Objects.UI;
using Server.Core;
using Server.VO;
using UnityEngine;

namespace Server.Handler
{
    public class ReadyHandler : MonoBehaviour
    {
        private int _currentReadyCount = 0;
        Flag readyFlag = new Flag();

        private void Awake()
        {
            BufferHandler.Instance.Add("ready", data => {
                ReadyVO vo = JsonUtility.FromJson<ReadyVO>(data);

                UserManager.Instance.GetUser(vo.id).ready = vo.status;

                _currentReadyCount += vo.status ? 1 : -1;

                readyFlag.Set();
            });

            StartCoroutine(SetImage());
        }

        IEnumerator SetImage()
        {
            while(true)
            {
                yield return new WaitUntil(readyFlag.Get);
                ReadyIcon.Instance.SetIcon(_currentReadyCount);
            }

        }
    }
}