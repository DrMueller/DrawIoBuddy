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
        }
    }
}