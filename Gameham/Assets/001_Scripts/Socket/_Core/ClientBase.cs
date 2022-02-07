using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Server.Client.Core
{
    public class ClientBase : MonoBehaviour
    {
        [SerializeField]    private int m_id    = -1;
                            public  int ID      => m_id;

        /// <summary>
        /// 아이디를 설정합니다.
        /// </summary>
        public void SetID(int id) => m_id = id;
    }
}