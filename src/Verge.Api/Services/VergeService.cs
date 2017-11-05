using ServiceStack;
using System;
using System.Net;
using System.Threading.Tasks;
using Verge.Api.Model;

namespace Verge.Api.Services
{
    public class VergeService : Service
    {
        public IVergeConfig VergeConfig { get; set; }

        public ICommandValidator CommandValidator { get; set; }

        public async Task<string> Any(RpcCommand request)
        {
            var validation = CommandValidator.Validate(request);
            if (validation.Valid)
            {
                return await PostRequest(request);
            }
            else
            {
                throw new HttpError(HttpStatusCode.BadRequest, validation.ErrorText);
            }
        }

        private async Task<string> PostRequest(RpcCommand request)
        {
            try
            {
                using (var client = new JsonHttpClient(VergeConfig.GetUri()))
                {
                    client.AddHeader("Authorization", VergeConfig.GetAuthHeaderValue());
                    var response = await client.PostAsync<string>(new Payload(request));
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw new HttpError(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
