using Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Elements;
using Mmu.DrawIoBuddy.Domain.Areas.StringNative;

namespace Mmu.DrawIoBuddy.DrawIoGateway.Areas.DrawingElements.Services
{
    public interface IShapeDisplayService
    {
        DrawIoString CreateDisplayString(IShape shape);
    }
}