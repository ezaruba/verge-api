using System;
using Verge.Api.Model;

namespace Verge.Api.Validators
{
    public sealed class GetBlockValidator : RpcValidatorBase
    {
        public GetBlockValidator() : base(RpcMethod.getBlock)
        {
        }

        protected override bool ValidateParameters(Array parameters)
        {
            return parameters != null && parameters.Length == 1;
        }

        protected override string GetErrorText()
        {
            return "Expecting no parameters";
        }
    }

    public sealed class GetBalanceValidator : RpcValidatorBase
    {
        public GetBalanceValidator() : base(RpcMethod.getBalance)
        {
        }

        protected override bool ValidateParameters(Array parameters)
        {
            return parameters != null && parameters.Length == 1;
        }

        protected override string GetErrorText()
        {
            return "Expecting no parameters";
        }
    }
}
