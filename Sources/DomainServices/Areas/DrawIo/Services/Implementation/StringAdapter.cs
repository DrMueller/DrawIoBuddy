using System;
using System.Net;

namespace Mmu.DrawIoBuddy.DomainServices.Areas.DrawIo.Services.Implementation
{
    public class StringAdapter : IStringAdapter
    {
        public string DecodeToNativeString(string drawIoString)
        {
            return WebUtility.UrlDecode(drawIoString);
        }

        public string EncodeToDrawIoString(string nativeString)
        {
            return Uri.EscapeUriString(nativeString);
        }
    }
}