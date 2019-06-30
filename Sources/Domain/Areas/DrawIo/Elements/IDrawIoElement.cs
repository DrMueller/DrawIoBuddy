using System.Collections.Generic;
using Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Xml;

namespace Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Elements
{
    public interface IDrawIoElement
    {
        IReadOnlyCollection<IMxElement> ToMxElements();
    }
}