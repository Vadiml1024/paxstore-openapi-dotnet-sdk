using Newtonsoft.Json;

namespace Paxstore.OpenApi.Model
{
    public class TerminalSnCopyRequest
    {
        [JsonProperty("serialNo")]
        public string SerialNo { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tid")]
        public string TID { get; set; }

        [JsonProperty("newSerialNo")]
        public string NewSerialNo { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
