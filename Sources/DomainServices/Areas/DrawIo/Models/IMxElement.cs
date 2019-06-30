using System.Xml.Linq;

namespace Mmu.DrawIoBuddy.DomainServices.Areas.DrawIo.Models
{
    public interface IMxElement
    {
        XObject ToXml();
    }
}