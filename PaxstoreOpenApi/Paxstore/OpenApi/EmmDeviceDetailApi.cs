using Newtonsoft.Json;
using Paxstore.OpenApi.Base;
using Paxstore.OpenApi.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Paxstore.OpenApi
{
    public class EmmDeviceDetailApi : BaseApi
    {
        private const string GET_EMM_DEVICE_DETAIL_URL = "/v1/3rdsys/emm/devices/{emmDeviceId}/detail";

        public EmmDeviceDetailApi(string baseUrl, string apiKey, string apiSecret, TimeZoneInfo timeZoneInfo = null, int timeout = 5000, IWebProxy proxy = null)
            : base(baseUrl, apiKey, apiSecret, timeZoneInfo, timeout, proxy)
        {
        }

        public EmmDeviceDetailApi(string baseUrl, string apiKey, string apiSecret, TimeZoneInfo timeZoneInfo) : base(baseUrl, apiKey, apiSecret, timeZoneInfo, DEFAULT_TIMEOUT, null)
        {
        }

        public EmmDeviceDetailApi(string baseUrl, string apiKey, string apiSecret, IWebProxy proxy) : base(baseUrl, apiKey, apiSecret, null, DEFAULT_TIMEOUT, proxy)
        {
        }

        public EmmDeviceDetailApi(string baseUrl, string apiKey, string apiSecret, int timeout) : base(baseUrl, apiKey, apiSecret, null, timeout, null)
        {
        }

        public Result<EmmDeviceDetail> GetEmmDeviceDetail(long emmDeviceId)
        {
            IList<string> validationErrs = ValidateId(emmDeviceId, "parameterEmmDeviceIdInvalid");
            if (validationErrs.Count > 0)
            {
                return new Result<EmmDeviceDetail>(validationErrs);
            }
            RestRequest request = new RestRequest(GET_EMM_DEVICE_DETAIL_URL, Method.Get);
            request.AddUrlSegment("emmDeviceId", emmDeviceId);
            var responseContent = Execute(request);
            EmmDeviceDetailResponse emmDeviceDetailResponse = JsonConvert.DeserializeObject<EmmDeviceDetailResponse>(responseContent);
            Result<EmmDeviceDetail> result = new Result<EmmDeviceDetail>(emmDeviceDetailResponse);
            return result;
        }
    }
}
