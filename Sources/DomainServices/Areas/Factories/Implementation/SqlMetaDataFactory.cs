using System;
using System.Collections.Generic;
using Mmu.DrawIoBuddy.Domain;

namespace Mmu.DrawIoBuddy.DomainServices.Areas.Factories.Implementation
{
    public class SqlMetaDataFactory : ISqlMetaDataFactory
    {
        public IReadOnlyCollection<SqlMetaData> Parse(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return new List<SqlMetaData>();
            }

            var lines = str.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = new List<SqlMetaData>();

            foreach (var line in lines)
            {
                var cells = line.Split(';');
                result.Add(new SqlMetaData(cells[0], cells[1], cells[2], cells[3]));
            }

            return result;
        }
    }
}