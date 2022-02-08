using System;
using System.Collections.Generic;

namespace Server.VO
{
    [Serializable]
    public class RoomQueryVO
    {
        public List<RoomDataVO> roomData;
    }

    [Serializable]
    public class RoomDataVO
    {
        public bool isPlaying;
        public int roomNumber;
        public int players;
    }
}