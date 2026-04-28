namespace Paxstore.OpenApi.Model
{
    public class TerminalSystemUsage
    {
        public string SerialNo { get; set; }

        public string TID { get; set; }

        public long? CpuUsage { get; set; }

        public long? MemoryUsage { get; set; }

        public long? StorageUsage { get; set; }

        public long? UpdatedTime { get; set; }
    }
}
