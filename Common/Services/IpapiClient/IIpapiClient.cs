using Models.Ipapi;
using System.Net;

namespace Common.Services.IpapiClient
{
    public interface IIpapiClient
    {
        Task<IpapiResult> GetLocationInformation(IPAddress ipAddress);
    }
}