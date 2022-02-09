using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects.UI
{
    public class ReadyIcon : MonoSingleton<ReadyIcon>
    {
        [SerializeField] GameObject[] _readyIcons = new GameObject[2];

        private void Awake()
        {
            for (int i = 0; i < _readyIcons.Length; ++i) {
                _readyIcons[i].SetActive(false); // 무지성 코딩
            }
        }

        public void SetIcon(int readyCount)
        {
            for (int i = 0; i < _readyIcons.Length; ++i) {
                _readyIcons[i].SetActive(false); // 무지성 코딩
            }

            for (int i = 0; i < readyCount; ++i) {
                _readyIcons[i].SetActive(true);
            }
        }
    }

}