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

                UserDataVO user = UserManager.Instance.GetUser(vo.id);
                if(user == null) {
                    user = new UserDataVO(vo.id);
                    UserManager.Instance.Add(vo.id, user);
                }

                user.ready = vo.status;
                
                _currentReadyCount = Mathf.Clamp(_currentReadyCount + (vo.status ? 1 : -1), 0, 2);

                Debug.Log(_currentReadyCount + " CNT");

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