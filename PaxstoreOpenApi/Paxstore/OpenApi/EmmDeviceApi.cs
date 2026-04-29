using Newtonsoft.Json;
using Paxstore.OpenApi.Base;
using Paxstore.OpenApi.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Paxstore.OpenApi
{
    public class EmmDeviceApi : BaseApi
    {
        private const string SEARCH_EMM_DEVICE_URL = "/v1/3rdsys/emm/devices";
        private const string GET_EMM_DEVICE_URL = "/v1/3rdsys/emm/devices/{emmDeviceId}";

        public EmmDeviceApi(string baseUrl, string apiKey, string apiSecret, TimeZoneInfo timeZoneInfo = null, int timeout = 5000, IWebProxy proxy = null)
            : base(baseUrl, apiKey, apiSecret, timeZoneInfo, timeout, proxy)
        {
        }

        public EmmDeviceApi(string baseUrl, string apiKey, string apiSecret, TimeZoneInfo timeZoneInfo) : base(baseUrl, apiKey, apiSecret, timeZoneInfo, DEFAULT_TIMEOUT, null)
        {
        }

        public EmmDeviceApi(string baseUrl, string apiKey, string apiSecret, IWebProxy proxy) : base(baseUrl, apiKey, apiSecret, null, DEFAULT_TIMEOUT, proxy)
        {
        }

        public EmmDeviceApi(string baseUrl, string apiKey, string apiSecret, int timeout) : base(baseUrl, apiKey, apiSecret, null, timeout, null)
        {
        }

        public Result<EmmDevice> SearchEmmDevice(int pageNo, int pageSize, string serialNo, string modelName, string resellerName, string merchantName, string emmStatus)
        {
            IList<string> validationErrs = ValidatePageSizeAndPageNo(pageSize, pageNo);
            if (validationErrs.Count > 0)
            {
                return new Result<EmmDevice>(validationErrs);
            }
            RestRequest request = new RestRequest(SEARCH_EMM_DEVICE_URL, Method.Get);
            request.AddParameter(Constants.PAGINATION_PAGE_NO, pageNo.ToString());
            request.AddParameter(Constants.PAGINATION_PAGE_LIMIT, pageSize.ToString());
            if (!string.IsNullOrEmpty(serialNo))
            {
                request.AddParameter("serialNo", serialNo);
            }
            if (!string.IsNullOrEmpty(modelName))
            {
                request.AddParameter("modelName", modelName);
            }
            if (!string.IsNullOrEmpty(resellerName))
            {
                request.AddParameter("resellerName", resellerName);
            }
            if (!string.IsNullOrEmpty(merchantName))
            {
                request.AddParameter("merchantName", merchantName);
            }
            if (!string.IsNullOrEmpty(emmStatus))
            {
                request.AddParameter("emmStatus", emmStatus);
            }
            var responseContent = Execute(request);
            EmmDevicePageResponse emmDevicePage = JsonConvert.DeserializeObject<EmmDevicePageResponse>(responseContent);
            Result<EmmDevice> result = new Result<EmmDevice>(emmDevicePage);
            return result;
        }

        public Result<EmmDevice> SearchEmmDevice(int pageNo, int pageSize)
        {
            return SearchEmmDevice(pageNo, pageSize, null, null, null, null, null);
        }

        public Result<EmmDevice> GetEmmDevice(long emmDeviceId)
        {
            IList<string> validationErrs = ValidateId(emmDeviceId, "parameterEmmDeviceIdInvalid");
            if (validationErrs.Count > 0)
            {
                return new Result<EmmDevice>(validationErrs);
            }
            RestRequest request = new RestRequest(GET_EMM_DEVICE_URL, Method.Get);
            request.AddUrlSegment("emmDeviceId", emmDeviceId);
            var responseContent = Execute(request);
            EmmDeviceResponse emmDeviceResponse = JsonConvert.DeserializeObject<EmmDeviceResponse>(responseContent);
            Result<EmmDevice> result = new Result<EmmDevice>(emmDeviceResponse);
            return result;
        }
    }
}
