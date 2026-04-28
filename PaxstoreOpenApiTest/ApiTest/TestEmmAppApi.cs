using Newtonsoft.Json;
using NUnit.Framework;
using Paxstore.OpenApi;
using Paxstore.OpenApi.Model;
using Serilog;

namespace Paxstore.Test
{
    [TestFixture()]
    class TestEmmAppApi : BaseTest
    {
        public static EmmAppApi API = new EmmAppApi(TestConst.API_BASE_URL, TestConst.API_KEY, TestConst.API_SECRET);

        [Test]
        public void TestSearchEmmAppInvalidPageNo()
        {
            Result<EmmApp> result = API.SearchEmmApp(-1, 10, null, null);
            Log.Debug("Result=\n{0}", JsonConvert.SerializeObject(result));
            Assert.AreEqual(result.BusinessCode, -1);
        }

        [Test]
        public void TestSearchEmmApp()
        {
            Result<EmmApp> result = API.SearchEmmApp(1, 10);
            Log.Debug("Result=\n{0}", JsonConvert.SerializeObject(result));
            Assert.AreEqual(result.BusinessCode, 0);
        }

        [Test]
        public void TestGetEmmAppInvalidId()
        {
            Result<EmmApp> result = API.GetEmmApp(0);
            Log.Debug("Result=\n{0}", JsonConvert.SerializeObject(result));
            Assert.AreEqual(result.BusinessCode, -1);
        }

        [Test]
        public void TestGetEmmAppNotExist()
        {
            Result<EmmApp> result = API.GetEmmApp(9999999);
            Log.Debug("Result=\n{0}", JsonConvert.SerializeObject(result));
            Assert.AreNotEqual(result.BusinessCode, 0);
        }
    }
}
