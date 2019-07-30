using System;
using System.Linq;
using System.Net;
using System.Text;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.DrawIoBuddy.DrawIoGateway.Areas.Strings.Models
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
            const int UriMaxLength = 65519;
            var chunkedStr = _str.Chunk(UriMaxLength);
            StringBuilder sb = new StringBuilder();

            chunkedStr.ForEach(chunk =>
            {
                sb.Append(Uri.EscapeUriString(new string(chunk.ToArray())));
            });

            return sb.ToString();
        }
    }
}