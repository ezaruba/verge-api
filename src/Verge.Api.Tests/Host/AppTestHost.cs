using ServiceStack;
using Verge.Api.Model;
using Verge.Api.Services;

namespace Verge.Api.Tests.Host
{
    public class AppTestHost : AppSelfHostBase
    {
        public AppTestHost() : base("Verge Unit Tests", typeof(VergeService).Assembly) { }

        public override void Configure(Funq.Container container)
        {
            container.Register(CreateTestConfig());
            container.Register<ICommandValidator>(AppHost.CreateValidator());
        }

        private IVergeConfig CreateTestConfig()
        {
            return new Config
            {
                Https = false,
                Host = "192.168.1.199",
                User = "vergeuser",
                Pass = "vergepass",
                Port = 20102
            };
        }
    }
}
