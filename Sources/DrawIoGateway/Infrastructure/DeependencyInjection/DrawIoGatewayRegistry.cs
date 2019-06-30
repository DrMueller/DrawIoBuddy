using Mmu.DrawIoBuddy.DrawIoGateway.Areas.DrawingElements.Services;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.DrawingElements.Services.Implementation;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.XmlInternals.Services;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.XmlInternals.Services.Implementation;
using StructureMap;

namespace Mmu.DrawIoBuddy.DrawIoGateway.Infrastructure.DeependencyInjection
{
    public class DrawIoGatewayRegistry : Registry
    {
        public DrawIoGatewayRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<DrawIoGatewayRegistry>();
                scanner.WithDefaultConventions();
            });

            For<IXmlDocumentFactory>().Use<XmlDocumentFactory>().Singleton();
            For<IShapeDisplayService>().Use<ShapeDisplayService>().Singleton();
        }
    }
}