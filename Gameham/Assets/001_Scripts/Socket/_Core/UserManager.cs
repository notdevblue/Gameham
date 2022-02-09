using System;
using System.Collections.Generic;
using Server.VO;

namespace Server.Core
{
    public class UserManager : Singleton<UserManager>
    {
        private Dictionary<int, UserDataVO> m_userDictionary;
        private UserDataVO m_playerData;

        public UserManager()
        {
            m_userDictionary = new Dictionary<int, UserDataVO>();
        }

        public void Add(int key, UserDataVO value)
        {
            if (m_userDictionary.ContainsKey(key)) {
                UnityEngine.Debug.LogError("이미 등록된 ID");
                return;
            }

            m_userDictionary.Add(key, value);
        }

        public UserDataVO GetUser(int key)
        {
            if(!m_userDictionary.ContainsKey(key)) {
                return null;
            } else {
                return m_userDictionary[key];
            }
        }

        public void SetPlayerData(int key, UserDataVO data)
        {
            if(m_userDictionary.ContainsKey(key)) {
                UnityEngine.Debug.LogError("이미 등록된 ID");
                return;
            }

            m_userDictionary.Add(key, data);
            m_playerData = data;
        }

        public UserDataVO GetPlayerData() => m_playerData;

    }
}