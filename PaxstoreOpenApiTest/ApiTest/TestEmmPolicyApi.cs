using Newtonsoft.Json;
using NUnit.Framework;
using Paxstore.OpenApi;
using Paxstore.OpenApi.Model;
using Serilog;

namespace Paxstore.Test
{
    [TestFixture()]
    class TestEmmPolicyApi : BaseTest
    {
        public static EmmPolicyApi API = new EmmPolicyApi(TestConst.API_BASE_URL, TestConst.API_KEY, TestConst.API_SECRET);

        [Test]
        public void TestSearchEmmPolicyInvalidPageNo()
        {
            Result<EmmPolicy> result = API.SearchEmmPolicy(-1, 10, null);
            Log.Debug("Result=\n{0}", JsonConvert.SerializeObject(result));
            Assert.AreEqual(result.BusinessCode, -1);
        }

        [Test]
        public void TestSearchEmmPolicy()
        {
            Result<EmmPolicy> result = API.SearchEmmPolicy(1, 10);
            Log.Debug("Result=\n{0}", JsonConvert.SerializeObject(result));
            Assert.AreEqual(result.BusinessCode, 0);
        }

        [Test]
        public void TestGetEmmPolicyInvalidId()
        {
            Result<EmmPolicy> result = API.GetEmmPolicy(0);
            Log.Debug("Result=\n{0}", JsonConvert.SerializeObject(result));
            Assert.AreEqual(result.BusinessCode, -1);
        }

        [Test]
        public void TestGetEmmPolicyNotExist()
        {
            Result<EmmPolicy> result = API.GetEmmPolicy(9999999);
            Log.Debug("Result=\n{0}", JsonConvert.SerializeObject(result));
            Assert.AreNotEqual(result.BusinessCode, 0);
        }
    }
}
