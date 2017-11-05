using System;
using Verge.Api.Model;

namespace Verge.Api.Validators
{
    public sealed class GetDifficultyValidator : RpcValidatorBase
    {
        public GetDifficultyValidator() : base(RpcMethod.getDifficulty)
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
