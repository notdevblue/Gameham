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
            m_userDictionary.Add(key, value);
        }

        public void SetPlayerData(UserDataVO data)
        {
            m_playerData = data;
        }

        public UserDataVO GetPlayerData() => m_playerData;

    }
}