using Mmu.DrawIoBuddy.DrawIoGateway.Areas.Strings.Models;

namespace Mmu.DrawIoBuddy.DomainServices.Areas.StringEncoding.Services.Implementation
{
    public class StringEncodingService : IStringEncodingService
    {
        public string Decode(string drawIoString)
        {
            return new DrawIoString(drawIoString).DecodeString();
        }

        public string Encode(string nativeString)
        {
            return new DrawIoString(nativeString).EncodeString();
        }
    }
}