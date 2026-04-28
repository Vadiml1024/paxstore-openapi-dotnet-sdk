using Newtonsoft.Json;
using NUnit.Framework;
using Paxstore.OpenApi;
using Paxstore.OpenApi.Model;
using Serilog;

namespace Paxstore.Test
{
    [TestFixture()]
    class TestFactoryModelApi : BaseTest
    {
        public static FactoryModelApi API = new FactoryModelApi(TestConst.API_BASE_URL, TestConst.API_KEY, TestConst.API_SECRET);

        [Test]
        public void TestSearchFactoryModelInvalidPageNo()
        {
            Result<FactoryModel> result = API.SearchFactoryModel(-1, 10, null);
            Log.Debug("Result=\n{0}", JsonConvert.SerializeObject(result));
            Assert.AreEqual(result.BusinessCode, -1);
        }

        [Test]
        public void TestSearchFactoryModel()
        {
            Result<FactoryModel> result = API.SearchFactoryModel(1, 10, null);
            Log.Debug("Result=\n{0}", JsonConvert.SerializeObject(result));
            Assert.AreEqual(result.BusinessCode, 0);
        }

        [Test]
        public void TestGetFactoryModelInvalidId()
        {
            Result<FactoryModel> result = API.GetFactoryModel(0);
            Log.Debug("Result=\n{0}", JsonConvert.SerializeObject(result));
            Assert.AreEqual(result.BusinessCode, -1);
        }

        [Test]
        public void TestGetFactoryModelNotExist()
        {
            Result<FactoryModel> result = API.GetFactoryModel(9999999);
            Log.Debug("Result=\n{0}", JsonConvert.SerializeObject(result));
            Assert.AreNotEqual(result.BusinessCode, 0);
        }
    }
}
