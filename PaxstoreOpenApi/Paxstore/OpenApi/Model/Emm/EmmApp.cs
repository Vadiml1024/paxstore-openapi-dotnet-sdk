using System.Collections.Generic;

namespace Paxstore.OpenApi.Model
{
    public class EmmApp
    {
        public long ID { get; set; }

        public string AppName { get; set; }

        public string PackageName { get; set; }

        public string VersionName { get; set; }

        public string VersionCode { get; set; }

        public string OsType { get; set; }

        public string Status { get; set; }

        public long? CreatedDate { get; set; }

        public long? UpdatedDate { get; set; }
    }
}
