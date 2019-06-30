using StructureMap;

namespace Mmu.DrawIoBuddy.DomainServices.Infrastructure.DependencyInjection
{
    public class DomainServicesRegistry : Registry
    {
        public DomainServicesRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<DomainServicesRegistry>();
                scanner.WithDefaultConventions();
            });
        }
    }
}