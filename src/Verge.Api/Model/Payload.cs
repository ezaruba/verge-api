using System;

namespace Verge.Api.Model
{
    public class Payload
    {
        public Payload(RpcCommand command)
        {
            Id = GenerateId();
            Method = command.Method.ToString().ToLower();
            Params = command.Params;
        }

        public int Id { get; private set; }

        public string Method { get; private set; }

        public string[] @Params { get; private set; }

        private int GenerateId()
        {
            var t = (DateTime.UtcNow - new DateTime(1970, 1, 1));
            return (int)t.TotalSeconds;
        }
    }
}
