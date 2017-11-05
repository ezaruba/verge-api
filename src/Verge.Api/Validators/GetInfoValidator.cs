using System;
using Verge.Api.Model;

namespace Verge.Api.Validators
{
    public sealed class GetInfoValidator : RpcValidatorBase
    {
        public GetInfoValidator() : base(RpcMethod.getInfo)
        {
        }

        protected override bool ValidateParameters(Array parameters)
        {
            return parameters == null || parameters.Length == 0;
        }

        protected override string GetErrorText()
        {
            return "Expecting no parameters";
        }
    }
}
