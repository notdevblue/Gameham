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
        public List<int> players;
        public bool isPlaying;
        public int roomNumber;
    }
}