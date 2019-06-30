using Mmu.DrawIoBuddy.DrawIoGateway.Areas.DrawingElements.Models.Shapes;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.Strings.Models;

namespace Mmu.DrawIoBuddy.DrawIoGateway.Areas.DrawingElements.Services
{
    public interface IShapeDisplayService
    {
        DrawIoString CreateDisplayString(IShape shape);
    }
}