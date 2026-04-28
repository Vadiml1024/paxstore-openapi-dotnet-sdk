using Newtonsoft.Json;
using Paxstore.OpenApi.Base;
using Paxstore.OpenApi.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Paxstore.OpenApi
{
    public class TerminalGeoFenceWhiteListApi : BaseApi
    {
        private const string GET_TERMINAL_GEO_FENCE_WHITE_LIST_URL = "/v1/3rdsys/terminals/{terminalId}/geoFenceWhiteList";
        private const string UPDATE_TERMINAL_GEO_FENCE_WHITE_LIST_URL = "/v1/3rdsys/terminals/{terminalId}/geoFenceWhiteList";

        public TerminalGeoFenceWhiteListApi(string baseUrl, string apiKey, string apiSecret, TimeZoneInfo timeZoneInfo = null, int timeout = 5000, IWebProxy proxy = null)
            : base(baseUrl, apiKey, apiSecret, timeZoneInfo, timeout, proxy)
        {
        }

        public TerminalGeoFenceWhiteListApi(string baseUrl, string apiKey, string apiSecret, TimeZoneInfo timeZoneInfo) : base(baseUrl, apiKey, apiSecret, timeZoneInfo, DEFAULT_TIMEOUT, null)
        {
        }

        public TerminalGeoFenceWhiteListApi(string baseUrl, string apiKey, string apiSecret, IWebProxy proxy) : base(baseUrl, apiKey, apiSecret, null, DEFAULT_TIMEOUT, proxy)
        {
        }

        public TerminalGeoFenceWhiteListApi(string baseUrl, string apiKey, string apiSecret, int timeout) : base(baseUrl, apiKey, apiSecret, null, timeout, null)
        {
        }

        public Result<TerminalGeoFenceWhiteList> GetTerminalGeoFenceWhiteList(long terminalId)
        {
            IList<string> validationErrs = ValidateId(terminalId, "terminalIdInvalid");
            if (validationErrs.Count > 0)
            {
                return new Result<TerminalGeoFenceWhiteList>(validationErrs);
            }
            RestRequest request = new RestRequest(GET_TERMINAL_GEO_FENCE_WHITE_LIST_URL, Method.Get);
            request.AddUrlSegment("terminalId", terminalId);
            var responseContent = Execute(request);
            TerminalGeoFenceWhiteListResponse response = JsonConvert.DeserializeObject<TerminalGeoFenceWhiteListResponse>(responseContent);
            Result<TerminalGeoFenceWhiteList> result = new Result<TerminalGeoFenceWhiteList>(response);
            return result;
        }

        public Result<string> UpdateTerminalGeoFenceWhiteList(long terminalId, TerminalGeoFenceWhiteListUpdateRequest updateRequest)
        {
            List<string> validationErrs = new List<string>();
            IList<string> idErrors = ValidateId(terminalId, "terminalIdInvalid");
            foreach (var err in idErrors) validationErrs.Add(err);
            if (updateRequest == null)
            {
                validationErrs.Add(GetMsgByKey("parameterTerminalGeoFenceWhiteListUpdateRequestIsNull"));
            }
            if (validationErrs.Count > 0)
            {
                return new Result<string>(validationErrs);
            }
            RestRequest request = new RestRequest(UPDATE_TERMINAL_GEO_FENCE_WHITE_LIST_URL, Method.Put);
            request.AddUrlSegment("terminalId", terminalId);
            var requestJson = JsonConvert.SerializeObject(updateRequest);
            request.AddParameter(Constants.CONTENT_TYPE_JSON, requestJson, ParameterType.RequestBody);
            string responseContent = Execute(request);
            EmptyResponse emptyResponse = JsonConvert.DeserializeObject<EmptyResponse>(responseContent);
            Result<string> result = new Result<string>(emptyResponse);
            return result;
        }
    }
}
