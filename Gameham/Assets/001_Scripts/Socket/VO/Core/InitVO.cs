using System;

namespace Server.VO
{
    [Serializable]
    public class InitVO
    {
        public int id;
        
        public InitVO(int id)
        {
            this.id = id;
        }
    }
}