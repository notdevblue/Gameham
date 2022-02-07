namespace Server.Core.VO
{
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