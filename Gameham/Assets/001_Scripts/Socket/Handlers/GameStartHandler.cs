using UnityEngine;
using UnityEngine.SceneManagement;
using Server.VO;
using Server.Core;
using System.Collections;

namespace Server.Handler
{
    public class GameStartHandler : MonoBehaviour
    {
        Flag started = new Flag();

        private void Awake()
        {
            BufferHandler.Instance.Add("start", data => {
                Debug.Log("Game started");

                started.Set();
            });

            StartCoroutine(StartGame());
        }

        IEnumerator StartGame()
        {
            while(true)
            {
                yield return new WaitUntil(started.Get);
                SceneManager.LoadScene("ArrowShotScene");
            }
        }
    }
}