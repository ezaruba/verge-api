using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;

namespace Verge.Api.Model
{
    public interface ICommandValidator
    {
        IValidationResult Validate(RpcCommand command);
    }

    public class CommandValidator : ICommandValidator
    {
        private readonly IDictionary<RpcMethod, ICommandValidator> _validators = new Dictionary<RpcMethod, ICommandValidator>();

        public IValidationResult Validate(RpcCommand command)
        {
            if (command == null)
            {
                return new ValidationResult
                {
                    ErrorText = "Command expected"
                };
            }

            if (!_validators.ContainsKey(command.Method))
            {
                return new ValidationResult
                {
                    ErrorText = "Command not implemented"
                };
            }

            return _validators[command.Method].Validate(command);
        }

        public void Register(RpcValidatorBase validator)
        {
            if (_validators.ContainsKey(validator.Method))
            {
                throw new ArgumentException($"Validator for {validator.Method} already registered");
            }

            _validators.Add(validator.Method, validator);
        }
    }

    public interface IValidationResult
    {
        bool Valid { get; }
        bool RequiresUnlock { get; set; }
        string ErrorText { get; set; }
    }

    public sealed class ValidationResult : IValidationResult
    {
        public bool Valid { get; internal set; }
        public bool RequiresUnlock { get; set; }
        public string ErrorText { get; set; }
    }

    public abstract class RpcValidatorBase : ICommandValidator
    {
        private static readonly IDictionary<RpcMethod, bool> _unlockRequired = new Dictionary<RpcMethod, bool>();

        static RpcValidatorBase()
        {
            _unlockRequired.Add(RpcMethod.dumpPrivKey, true);
            _unlockRequired.Add(RpcMethod.importPrivKey, true);
            _unlockRequired.Add(RpcMethod.keyPoolRefill, true);
            _unlockRequired.Add(RpcMethod.sendFrom, true);
            _unlockRequired.Add(RpcMethod.sendMany, true);
            _unlockRequired.Add(RpcMethod.sendToAddress, true);
            _unlockRequired.Add(RpcMethod.signMessage, true);
            _unlockRequired.Add(RpcMethod.sendRawTransaction, true);
        }

        protected RpcValidatorBase(RpcMethod method)
        {
            Method = method;
        }

        public IValidationResult Validate(RpcCommand command)
        {
            return new ValidationResult
            {
                Valid = ValidateParameters(command.Params),
                RequiresUnlock = _unlockRequired.ContainsKey(command.Method),
                ErrorText = GetErrorText()
            };
        }

        public RpcMethod Method { get; }

        protected abstract bool ValidateParameters(Array parameters);

        protected abstract string GetErrorText();
    }
}
