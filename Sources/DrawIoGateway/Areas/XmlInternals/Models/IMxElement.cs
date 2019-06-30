using System.Xml.Linq;

namespace Mmu.DrawIoBuddy.DrawIoGateway.Areas.XmlInternals.Models
{
    internal interface IMxElement
    {
        XObject ToXml();
    }
}