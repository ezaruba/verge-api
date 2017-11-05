using ServiceStack;
using System.Collections.Generic;

namespace Verge.Api.Model
{
    [Route("/command")]
    public class RpcCommand : IReturn<string>
    {
        public RpcMethod Method { get; set; }

        public string[] @Params { get; set; }
    }
}
