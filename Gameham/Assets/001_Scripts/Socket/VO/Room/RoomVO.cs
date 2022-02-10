using System;

namespace Server.VO
{
    [Serializable]
    public class RoomVO
    {
        public int roomid;
        public int id;

        public RoomVO(int roomid, int id)
        {
            this.roomid = roomid;
            this.id = id;
        }
    }
}