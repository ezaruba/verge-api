using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceStack;
using System.Threading.Tasks;
using Verge.Api.Model;
using Verge.Api.Tests.Host;

namespace Verge.Api.Tests.Tests
{
    [TestClass]
    public sealed class CommandTests
    {
        private static ServiceStackHost appHost;

        private const string Wallet = "D9KbfBSugsx5UnbzF5d3MwBj3mF6k1o7wv";
        private const string Passphrase = "vergepassphrase";
        private readonly string baseUrl = "http://localhost:4200";


        [TestInitialize]
        public void Initialize()
        {
            if (appHost == null)
            {
                appHost = new AppTestHost()
                .Init()
                .Start(baseUrl);
            }
        }

        [TestMethod]
        public async Task GetInfo_WalletVersion_Equals_60000()
        {
            var info = await Post<GetInfo>(RpcMethod.getInfo);
            Assert.IsNotNull(info.version);
            Assert.AreEqual(info.walletversion, 60000);
        }

        private async Task<T> Post<T>(RpcMethod method, string[] parameters = null)
        {
            using (var client = new JsonServiceClient(baseUrl))
            {
                var command = new RpcCommand
                {
                    Method = method,
                    Params = parameters
                };
                var response = await client.PostAsync(command);
                var rpcresult = response.FromJson<RpcResult<T>>();
                return rpcresult.result;
            }
        }
    }
}
