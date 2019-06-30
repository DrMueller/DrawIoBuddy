using System.Collections.Generic;
using System.Xml.Linq;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.XmlInternals.Models;

namespace Mmu.DrawIoBuddy.DrawIoGateway.Areas.XmlInternals.Services
{
    internal interface IXmlDocumentFactory
    {
        XDocument CreateFromElements(IReadOnlyCollection<IMxElement> elements);
    }
}