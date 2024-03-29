﻿using StructureMap;

namespace Mmu.DrawIoBuddy.WpfUI.Infrastructure.DependecyInjection
{
    public class WpfUIRegistry : Registry
    {
        public WpfUIRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<WpfUIRegistry>();
                scanner.WithDefaultConventions();
            });
        }
    }
}