using Funq;
using ServiceStack;
using System;
using Verge.Api.Model;
using Verge.Api.Services;
using System.Linq;
using ServiceStack.Auth;
using ServiceStack.Configuration;

namespace Verge.Api
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("Verge Api", typeof(VergeService).GetAssembly()) { }

        public Func<IVergeConfig> VergeConfig { get; set; }

        public static CommandValidator CreateValidator()
        {
            var validators = typeof(RpcValidatorBase)
                .Assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(RpcValidatorBase)) && !t.IsAbstract)
                .Select(t => (RpcValidatorBase)Activator.CreateInstance(t));

            var result = new CommandValidator();
            foreach (var validator in validators)
            {
                result.Register(validator);
            }
            return result;
        }

        public override void Configure(Container container)
        {
            SetConfig(CreateHostConfig());

            var vergeConfig = VergeConfig.Invoke();
            container.Register<IVergeConfig>(vergeConfig);
            container.Register<ICommandValidator>(CreateValidator());

            var authFeature = CreateAuth(AppSettings, vergeConfig);
            if (authFeature != null)
            {
                Plugins.Add(authFeature);
            }

            Plugins.Add(new PostmanFeature());
            Plugins.Add(new CorsFeature());
        }

        protected virtual HostConfig CreateHostConfig()
        {
            return new HostConfig()
            {
                DefaultRedirectPath = "/metadata"
            };
        }

        protected virtual AuthFeature CreateAuth(IAppSettings settings, IVergeConfig config)
        {
            return new AuthFeature(() => new AuthUserSession(), new IAuthProvider[] {
                new ApiKeyAuthProvider(AppSettings)
            });
        }
    }
}
