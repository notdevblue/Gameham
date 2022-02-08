using System;

namespace Server.VO
{
    [Serializable]
    public class StringVO
    {
        public string msg;

        public StringVO(string msg)
        {
            this.msg = msg;
        }
    }
}