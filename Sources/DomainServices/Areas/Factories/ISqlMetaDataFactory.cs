using System.Collections.Generic;
using Mmu.DrawIoBuddy.Domain;

namespace Mmu.DrawIoBuddy.DomainServices.Areas.Factories
{
    public interface ISqlMetaDataFactory
    {
        IReadOnlyCollection<SqlMetaData> Parse(string str);
    }
}