using System.Collections.Generic;

namespace Paxstore.OpenApi.Model
{
    public class TerminalGeoFenceWhiteList
    {
        public long TerminalId { get; set; }

        public List<string> GeoFenceIds { get; set; }
    }
}
