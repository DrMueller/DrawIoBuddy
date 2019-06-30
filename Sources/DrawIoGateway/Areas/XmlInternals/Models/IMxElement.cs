using System.Xml.Linq;

namespace Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Xml
{
    internal interface IMxElement
    {
        XObject ToXml();
    }
}