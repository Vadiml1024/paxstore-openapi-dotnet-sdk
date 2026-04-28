using Newtonsoft.Json;
using System.Collections.Generic;

namespace Paxstore.OpenApi.Model
{
    public class TerminalGeoFenceWhiteListUpdateRequest
    {
        [JsonProperty("geoFenceIds")]
        public List<string> GeoFenceIds { get; set; }
    }
}
