using System;

namespace Server.VO
{
    [Serializable]
    public class UserDataVO
    {
        public int id;
        
        public UserDataVO(int id)
        {
            this.id = id;
        }
    }
}