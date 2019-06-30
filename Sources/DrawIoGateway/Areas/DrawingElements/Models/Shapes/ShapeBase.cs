using System.Collections.Generic;
using Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Elements;
using Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Xml;

namespace Mmu.DrawIoBuddy.DrawIoGateway.Areas.DrawingElements.Models.Shapes
{
    public abstract class ShapeBase : IShape
    {
        internal abstract IReadOnlyCollection<IMxElement> ToMxElements();
    }
}