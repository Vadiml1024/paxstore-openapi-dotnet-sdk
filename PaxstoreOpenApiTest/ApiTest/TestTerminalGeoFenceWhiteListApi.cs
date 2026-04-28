using Newtonsoft.Json;
using NUnit.Framework;
using Paxstore.OpenApi;
using Paxstore.OpenApi.Model;
using Serilog;

namespace Paxstore.Test
{
    [TestFixture()]
    class TestTerminalGeoFenceWhiteListApi : BaseTest
    {
        public static TerminalGeoFenceWhiteListApi API = new TerminalGeoFenceWhiteListApi(TestConst.API_BASE_URL, TestConst.API_KEY, TestConst.API_SECRET);

        [Test]
        public void TestGetTerminalGeoFenceWhiteListInvalidId()
        {
            Result<TerminalGeoFenceWhiteList> result = API.GetTerminalGeoFenceWhiteList(0);
            Log.Debug("Result=\n{0}", JsonConvert.SerializeObject(result));
            Assert.AreEqual(result.BusinessCode, -1);
        }

        [Test]
        public void TestGetTerminalGeoFenceWhiteList()
        {
            Result<TerminalGeoFenceWhiteList> result = API.GetTerminalGeoFenceWhiteList(1);
            Log.Debug("Result=\n{0}", JsonConvert.SerializeObject(result));
            Assert.AreNotEqual(result.BusinessCode, -1);
        }

        [Test]
        public void TestUpdateTerminalGeoFenceWhiteListInvalidId()
        {
            TerminalGeoFenceWhiteListUpdateRequest updateRequest = new TerminalGeoFenceWhiteListUpdateRequest();
            Result<string> result = API.UpdateTerminalGeoFenceWhiteList(0, updateRequest);
            Log.Debug("Result=\n{0}", JsonConvert.SerializeObject(result));
            Assert.AreEqual(result.BusinessCode, -1);
        }

        [Test]
        public void TestUpdateTerminalGeoFenceWhiteListNullRequest()
        {
            Result<string> result = API.UpdateTerminalGeoFenceWhiteList(1, null);
            Log.Debug("Result=\n{0}", JsonConvert.SerializeObject(result));
            Assert.AreEqual(result.BusinessCode, -1);
        }
    }
}
