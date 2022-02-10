using System;

namespace Server.VO
{
    [Serializable]
    public class DataVO
    {
        public string type;
        public string payload;

        public DataVO(string type, string payload)
        {
            this.type = type;
            this.payload = payload;
        }
    }
}