using Mmu.DrawIoBuddy.DomainServices.Areas.DrawIo.Models;

namespace Mmu.DrawIoBuddy.DomainServices.Areas.DrawIo.Services
{
    public interface IXmlFactory
    {
        string CreateDrawIoXmlString(params IMxElement[] elements);
    }
}