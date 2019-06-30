using System.Collections.Generic;
using System.Xml.Linq;
using Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Xml;

namespace Mmu.DrawIoBuddy.DomainServices.Areas.DrawIo.Services
{
    internal interface IXmlFactory
    {
        XDocument CreateFromElements(IReadOnlyCollection<IMxElement> elements);
    }
}