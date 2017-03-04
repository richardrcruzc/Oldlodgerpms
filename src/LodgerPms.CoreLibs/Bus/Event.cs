namespace LodgerPms.CoreLibs.Bus
{
    public class Event : IMessage
    {
        public byte[] Version { get; set; }
    }
}