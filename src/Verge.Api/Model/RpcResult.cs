namespace Verge.Api.Model
{
    public class RpcResult<T>
    {
        public T result { get; set; }
        public object error { get; set; }
        public int id { get; set; }
    }

    public class GetInfo
    {
        public string version { get; set; }
        public int protocolversion { get; set; }
        public int walletversion { get; set; }
        public double balance { get; set; }
        public double newmint { get; set; }
        public double stake { get; set; }
        public int blocks { get; set; }
        public double moneysupply { get; set; }
        public int connections { get; set; }
        public string proxy { get; set; }
        public string ip { get; set; }
        public int pow_algo_id { get; set; }
        public string pow_algo { get; set; }
        public double difficulty { get; set; }
        public double difficulty_x17 { get; set; }
        public double difficulty_scrypt { get; set; }
        public double difficulty_groestl { get; set; }
        public double difficulty_lyra2re { get; set; }
        public double difficulty_blake { get; set; }
        public bool testnet { get; set; }
        public int keypoololdest { get; set; }
        public int keypoolsize { get; set; }
        public double paytxfee { get; set; }
        public string errors { get; set; }
    }
}
