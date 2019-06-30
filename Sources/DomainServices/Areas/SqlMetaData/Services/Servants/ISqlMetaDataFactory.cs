using System.Collections.Generic;
using Mmu.DrawIoBuddy.Domain;

namespace Mmu.DrawIoBuddy.DomainServices.Areas.SqlMetaData.Services.Servants
{
    public interface ISqlMetaDataFactory
    {
        IReadOnlyCollection<SqlMetaData2> Parse(string str);
    }
}