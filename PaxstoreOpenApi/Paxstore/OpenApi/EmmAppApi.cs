using Newtonsoft.Json;
using Paxstore.OpenApi.Base;
using Paxstore.OpenApi.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Paxstore.OpenApi
{
    public class EmmAppApi : BaseApi
    {
        private const string SEARCH_EMM_APP_URL = "/v1/3rdsys/emm/apps";
        private const string GET_EMM_APP_URL = "/v1/3rdsys/emm/apps/{emmAppId}";

        public EmmAppApi(string baseUrl, string apiKey, string apiSecret, TimeZoneInfo timeZoneInfo = null, int timeout = 5000, IWebProxy proxy = null)
            : base(baseUrl, apiKey, apiSecret, timeZoneInfo, timeout, proxy)
        {
        }

        public EmmAppApi(string baseUrl, string apiKey, string apiSecret, TimeZoneInfo timeZoneInfo) : base(baseUrl, apiKey, apiSecret, timeZoneInfo, DEFAULT_TIMEOUT, null)
        {
        }

        public EmmAppApi(string baseUrl, string apiKey, string apiSecret, IWebProxy proxy) : base(baseUrl, apiKey, apiSecret, null, DEFAULT_TIMEOUT, proxy)
        {
        }

        public EmmAppApi(string baseUrl, string apiKey, string apiSecret, int timeout) : base(baseUrl, apiKey, apiSecret, null, timeout, null)
        {
        }

        public Result<EmmApp> SearchEmmApp(int pageNo, int pageSize, string name, string packageName)
        {
            IList<string> validationErrs = ValidatePageSizeAndPageNo(pageSize, pageNo);
            if (validationErrs.Count > 0)
            {
                return new Result<EmmApp>(validationErrs);
            }
            RestRequest request = new RestRequest(SEARCH_EMM_APP_URL, Method.Get);
            request.AddParameter(Constants.PAGINATION_PAGE_NO, pageNo.ToString());
            request.AddParameter(Constants.PAGINATION_PAGE_LIMIT, pageSize.ToString());
            if (!string.IsNullOrEmpty(name))
            {
                request.AddParameter("name", name);
            }
            if (!string.IsNullOrEmpty(packageName))
            {
                request.AddParameter("packageName", packageName);
            }
            var responseContent = Execute(request);
            EmmAppPageResponse emmAppPage = JsonConvert.DeserializeObject<EmmAppPageResponse>(responseContent);
            Result<EmmApp> result = new Result<EmmApp>(emmAppPage);
            return result;
        }

        public Result<EmmApp> SearchEmmApp(int pageNo, int pageSize)
        {
            return SearchEmmApp(pageNo, pageSize, null, null);
        }

        public Result<EmmApp> GetEmmApp(long emmAppId)
        {
            IList<string> validationErrs = ValidateId(emmAppId, "parameterEmmAppIdInvalid");
            if (validationErrs.Count > 0)
            {
                return new Result<EmmApp>(validationErrs);
            }
            RestRequest request = new RestRequest(GET_EMM_APP_URL, Method.Get);
            request.AddUrlSegment("emmAppId", emmAppId);
            var responseContent = Execute(request);
            EmmAppResponse emmAppResponse = JsonConvert.DeserializeObject<EmmAppResponse>(responseContent);
            Result<EmmApp> result = new Result<EmmApp>(emmAppResponse);
            return result;
        }
    }
}
