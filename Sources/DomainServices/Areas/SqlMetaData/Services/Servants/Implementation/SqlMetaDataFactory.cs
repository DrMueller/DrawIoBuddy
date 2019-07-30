using System;
using System.Collections.Generic;
using Mmu.DrawIoBuddy.Domain;

namespace Mmu.DrawIoBuddy.DomainServices.Areas.SqlMetaData.Services.Servants.Implementation
{
    public class SqlMetaDataFactory : ISqlMetaDataFactory
    {
        public IReadOnlyCollection<Domain.SqlMetaData> Parse(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return new List<Domain.SqlMetaData>();
            }

            var lines = str.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            var result = new List<Domain.SqlMetaData>();

            foreach (var line in lines)
            {
                var cells = line.Split(';');
                result.Add(new Domain.SqlMetaData(cells[0], cells[1], cells[2], cells[3]));
            }

            return result;
        }
    }
}