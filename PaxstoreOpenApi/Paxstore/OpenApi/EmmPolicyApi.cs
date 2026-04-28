using Newtonsoft.Json;
using Paxstore.OpenApi.Base;
using Paxstore.OpenApi.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Paxstore.OpenApi
{
    public class EmmPolicyApi : BaseApi
    {
        private const string SEARCH_EMM_POLICY_URL = "/v1/3rdsys/emm/policies";
        private const string GET_EMM_POLICY_URL = "/v1/3rdsys/emm/policies/{emmPolicyId}";

        public EmmPolicyApi(string baseUrl, string apiKey, string apiSecret, TimeZoneInfo timeZoneInfo = null, int timeout = 5000, IWebProxy proxy = null)
            : base(baseUrl, apiKey, apiSecret, timeZoneInfo, timeout, proxy)
        {
        }

        public EmmPolicyApi(string baseUrl, string apiKey, string apiSecret, TimeZoneInfo timeZoneInfo) : base(baseUrl, apiKey, apiSecret, timeZoneInfo, DEFAULT_TIMEOUT, null)
        {
        }

        public EmmPolicyApi(string baseUrl, string apiKey, string apiSecret, IWebProxy proxy) : base(baseUrl, apiKey, apiSecret, null, DEFAULT_TIMEOUT, proxy)
        {
        }

        public EmmPolicyApi(string baseUrl, string apiKey, string apiSecret, int timeout) : base(baseUrl, apiKey, apiSecret, null, timeout, null)
        {
        }

        public Result<EmmPolicy> SearchEmmPolicy(int pageNo, int pageSize, string name)
        {
            IList<string> validationErrs = ValidatePageSizeAndPageNo(pageSize, pageNo);
            if (validationErrs.Count > 0)
            {
                return new Result<EmmPolicy>(validationErrs);
            }
            RestRequest request = new RestRequest(SEARCH_EMM_POLICY_URL, Method.Get);
            request.AddParameter(Constants.PAGINATION_PAGE_NO, pageNo.ToString());
            request.AddParameter(Constants.PAGINATION_PAGE_LIMIT, pageSize.ToString());
            if (!string.IsNullOrEmpty(name))
            {
                request.AddParameter("name", name);
            }
            var responseContent = Execute(request);
            EmmPolicyPageResponse emmPolicyPage = JsonConvert.DeserializeObject<EmmPolicyPageResponse>(responseContent);
            Result<EmmPolicy> result = new Result<EmmPolicy>(emmPolicyPage);
            return result;
        }

        public Result<EmmPolicy> SearchEmmPolicy(int pageNo, int pageSize)
        {
            return SearchEmmPolicy(pageNo, pageSize, null);
        }

        public Result<EmmPolicy> GetEmmPolicy(long emmPolicyId)
        {
            IList<string> validationErrs = ValidateId(emmPolicyId, "parameterEmmPolicyIdInvalid");
            if (validationErrs.Count > 0)
            {
                return new Result<EmmPolicy>(validationErrs);
            }
            RestRequest request = new RestRequest(GET_EMM_POLICY_URL, Method.Get);
            request.AddUrlSegment("emmPolicyId", emmPolicyId);
            var responseContent = Execute(request);
            EmmPolicyResponse emmPolicyResponse = JsonConvert.DeserializeObject<EmmPolicyResponse>(responseContent);
            Result<EmmPolicy> result = new Result<EmmPolicy>(emmPolicyResponse);
            return result;
        }
    }
}
