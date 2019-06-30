using System.Collections.Generic;
using Mmu.DrawIoBuddy.Domain;

namespace Mmu.DrawIoBuddy.DomainServices.Areas.Adapters
{
    public interface ISqlMetaDataToClassAdapter
    {
        string Adapt(IReadOnlyCollection<SqlMetaData> metaData);
    }
}