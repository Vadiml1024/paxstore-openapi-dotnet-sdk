using Newtonsoft.Json;
using NUnit.Framework;
using Paxstore.OpenApi;
using Paxstore.OpenApi.Model;
using Serilog;

namespace Paxstore.Test
{
    [TestFixture()]
    class TestEmmDeviceApi : BaseTest
    {
        public static EmmDeviceApi API = new EmmDeviceApi(TestConst.API_BASE_URL, TestConst.API_KEY, TestConst.API_SECRET);

        [Test]
        public void TestSearchEmmDeviceInvalidPageNo()
        {
            Result<EmmDevice> result = API.SearchEmmDevice(-1, 10, null, null, null, null, null);
            Log.Debug("Result=\n{0}", JsonConvert.SerializeObject(result));
            Assert.AreEqual(result.BusinessCode, -1);
        }

        [Test]
        public void TestSearchEmmDevice()
        {
            Result<EmmDevice> result = API.SearchEmmDevice(1, 10);
            Log.Debug("Result=\n{0}", JsonConvert.SerializeObject(result));
            Assert.AreEqual(result.BusinessCode, 0);
        }

        [Test]
        public void TestGetEmmDeviceInvalidId()
        {
            Result<EmmDevice> result = API.GetEmmDevice(0);
            Log.Debug("Result=\n{0}", JsonConvert.SerializeObject(result));
            Assert.AreEqual(result.BusinessCode, -1);
        }

        [Test]
        public void TestGetEmmDeviceNotExist()
        {
            Result<EmmDevice> result = API.GetEmmDevice(9999999);
            Log.Debug("Result=\n{0}", JsonConvert.SerializeObject(result));
            Assert.AreNotEqual(result.BusinessCode, 0);
        }
    }
}
