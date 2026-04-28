using Newtonsoft.Json;
using NUnit.Framework;
using Paxstore.OpenApi;
using Paxstore.OpenApi.Model;
using Serilog;

namespace Paxstore.Test
{
    [TestFixture()]
    class TestEmmDeviceDetailApi : BaseTest
    {
        public static EmmDeviceDetailApi API = new EmmDeviceDetailApi(TestConst.API_BASE_URL, TestConst.API_KEY, TestConst.API_SECRET);

        [Test]
        public void TestGetEmmDeviceDetailInvalidId()
        {
            Result<EmmDeviceDetail> result = API.GetEmmDeviceDetail(0);
            Log.Debug("Result=\n{0}", JsonConvert.SerializeObject(result));
            Assert.AreEqual(result.BusinessCode, -1);
        }

        [Test]
        public void TestGetEmmDeviceDetailNotExist()
        {
            Result<EmmDeviceDetail> result = API.GetEmmDeviceDetail(9999999);
            Log.Debug("Result=\n{0}", JsonConvert.SerializeObject(result));
            Assert.AreNotEqual(result.BusinessCode, 0);
        }
    }
}
