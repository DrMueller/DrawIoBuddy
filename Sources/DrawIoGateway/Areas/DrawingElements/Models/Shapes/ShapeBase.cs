using System.Collections.Generic;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.XmlInternals.Models;

namespace Mmu.DrawIoBuddy.DrawIoGateway.Areas.DrawingElements.Models.Shapes
{
    public abstract class ShapeBase : IShape
    {
        internal abstract IReadOnlyCollection<IMxElement> ToMxElements();
    }
}