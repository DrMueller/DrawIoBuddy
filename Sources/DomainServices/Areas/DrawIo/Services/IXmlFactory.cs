using System.Collections.Generic;
using Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Xml;

namespace Mmu.DrawIoBuddy.DomainServices.Areas.DrawIo.Services
{
    public interface IXmlFactory
    {
        string CreateDrawIoXmlString(IReadOnlyCollection<IMxElement> elements);
    }
}