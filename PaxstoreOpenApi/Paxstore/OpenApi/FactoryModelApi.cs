using Newtonsoft.Json;
using Paxstore.OpenApi.Base;
using Paxstore.OpenApi.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Paxstore.OpenApi
{
    public class FactoryModelApi : BaseApi
    {
        private const string SEARCH_FACTORY_MODEL_URL = "/v1/3rdsys/factoryModels";
        private const string GET_FACTORY_MODEL_URL = "/v1/3rdsys/factoryModels/{factoryModelId}";

        public FactoryModelApi(string baseUrl, string apiKey, string apiSecret, TimeZoneInfo timeZoneInfo = null, int timeout = 5000, IWebProxy proxy = null)
            : base(baseUrl, apiKey, apiSecret, timeZoneInfo, timeout, proxy)
        {
        }

        public FactoryModelApi(string baseUrl, string apiKey, string apiSecret, TimeZoneInfo timeZoneInfo) : base(baseUrl, apiKey, apiSecret, timeZoneInfo, DEFAULT_TIMEOUT, null)
        {
        }

        public FactoryModelApi(string baseUrl, string apiKey, string apiSecret, IWebProxy proxy) : base(baseUrl, apiKey, apiSecret, null, DEFAULT_TIMEOUT, proxy)
        {
        }

        public FactoryModelApi(string baseUrl, string apiKey, string apiSecret, int timeout) : base(baseUrl, apiKey, apiSecret, null, timeout, null)
        {
        }

        public Result<FactoryModel> SearchFactoryModel(int pageNo, int pageSize, string name)
        {
            IList<string> validationErrs = ValidatePageSizeAndPageNo(pageSize, pageNo);
            if (validationErrs.Count > 0)
            {
                return new Result<FactoryModel>(validationErrs);
            }
            RestRequest request = new RestRequest(SEARCH_FACTORY_MODEL_URL, Method.Get);
            request.AddParameter(Constants.PAGINATION_PAGE_NO, pageNo.ToString());
            request.AddParameter(Constants.PAGINATION_PAGE_LIMIT, pageSize.ToString());
            if (!string.IsNullOrEmpty(name))
            {
                request.AddParameter("name", name);
            }
            var responseContent = Execute(request);
            FactoryModelPageResponse factoryModelPage = JsonConvert.DeserializeObject<FactoryModelPageResponse>(responseContent);
            Result<FactoryModel> result = new Result<FactoryModel>(factoryModelPage);
            return result;
        }

        public Result<FactoryModel> SearchFactoryModel(int pageNo, int pageSize)
        {
            return SearchFactoryModel(pageNo, pageSize, null);
        }

        public Result<FactoryModel> GetFactoryModel(long factoryModelId)
        {
            IList<string> validationErrs = ValidateId(factoryModelId, "parameterFactoryModelIdInvalid");
            if (validationErrs.Count > 0)
            {
                return new Result<FactoryModel>(validationErrs);
            }
            RestRequest request = new RestRequest(GET_FACTORY_MODEL_URL, Method.Get);
            request.AddUrlSegment("factoryModelId", factoryModelId);
            var responseContent = Execute(request);
            FactoryModelResponse factoryModelResponse = JsonConvert.DeserializeObject<FactoryModelResponse>(responseContent);
            Result<FactoryModel> result = new Result<FactoryModel>(factoryModelResponse);
            return result;
        }
    }
}
