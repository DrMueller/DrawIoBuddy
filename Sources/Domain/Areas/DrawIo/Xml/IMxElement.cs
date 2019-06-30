using System.Xml.Linq;

namespace Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Xml
{
    public interface IMxElement
    {
        XObject ToXml();
    }
}