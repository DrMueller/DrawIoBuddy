using System;
using System.Net;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.DrawIoBuddy.Domain.Areas.StringNative
{
    public class DrawIoString
    {
        private readonly string _str;

        public DrawIoString(string str)
        {
            Guard.StringNotNullOrEmpty(() => str);

            _str = str;
        }

        public string DecodeString()
        {
            return WebUtility.UrlDecode(_str);
        }

        public string EncodeString()
        {
            return Uri.EscapeUriString(_str);
        }
    }
}