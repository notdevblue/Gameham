using System;

namespace Server.VO
{
    [Serializable]
    public class UserDataVO
    {
        public int id;
        public int roomid = -1;
        public bool ready = false;

        public UserDataVO(int id)
        {
            this.id = id;
        }
    }
}