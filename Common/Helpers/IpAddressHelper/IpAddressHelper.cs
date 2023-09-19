using System.Net;

namespace Common.Helpers.IpAddressHelper
{
    public static class IpAddressHelper
    {
        public static IEnumerable<IPAddress> GetAddresses()
        {
            var count = 0;
            var addresses = new List<IPAddress>();

            while (count != 10)
            {
                var address = Generate();

                if (IsPrivateIpAddress(address)) continue;

                addresses.Add(address);
                count++;
            }

            return addresses;
        }

        private static IPAddress Generate()
        {
            var random = new Random();

            byte[] ipBytes = new byte[4];
            random.NextBytes(ipBytes);

            return new IPAddress(ipBytes);
        }

        private static bool IsPrivateIpAddress(IPAddress ipAddress)
        {
            var ipBytes = ipAddress.GetAddressBytes();

            return (ipBytes[0] == 10) || (ipBytes[0] == 172 && ipBytes[1] >= 16 && ipBytes[1] <= 31) || (ipBytes[0] == 192 && ipBytes[1] == 168);
        }
    }
}