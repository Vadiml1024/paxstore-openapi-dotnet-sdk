using System.Collections.Generic;

namespace Paxstore.OpenApi.Model
{
    public class EmmDeviceDetail
    {
        public long ID { get; set; }

        public string SerialNo { get; set; }

        public string TID { get; set; }

        public string ModelName { get; set; }

        public string ResellerName { get; set; }

        public string MerchantName { get; set; }

        public string Status { get; set; }

        public string EmmStatus { get; set; }

        public long? EnrollmentTime { get; set; }

        public long? LastActiveTime { get; set; }

        public string AndroidVersion { get; set; }

        public string Imei { get; set; }

        public string PolicyName { get; set; }

        public List<string> InstalledApps { get; set; }
    }
}
