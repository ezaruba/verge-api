using System;
using System.Text;

namespace Verge.Api.Model
{
    public interface IVergeConfig
    {
        string Host { get; set; }
        bool Https { get; set; }
        string Pass { get; set; }
        int Port { get; set; }
        string User { get; set; }

        string GetAuthHeaderValue();
        string GetUri();
    }

    public class Config : IVergeConfig
    {
        public bool Https { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }

        public string GetUri()
        {
            return new UriBuilder(Https ? "https" : "http", Host, Port).ToString().ToLower();
        }

        public string GetAuthHeaderValue()
        {
            return $"Basic {Convert.ToBase64String(Encoding.ASCII.GetBytes($"{User}:{Pass}"))}";
        }
    }
}
