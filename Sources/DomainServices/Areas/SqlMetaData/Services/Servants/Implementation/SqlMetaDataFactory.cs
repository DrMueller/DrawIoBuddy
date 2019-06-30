using System;
using System.Collections.Generic;
using Mmu.DrawIoBuddy.Domain;

namespace Mmu.DrawIoBuddy.DomainServices.Areas.SqlMetaData.Services.Servants.Implementation
{
    public class SqlMetaDataFactory : ISqlMetaDataFactory
    {
        public IReadOnlyCollection<SqlMetaData2> Parse(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return new List<SqlMetaData2>();
            }

            var lines = str.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = new List<SqlMetaData2>();

            foreach (var line in lines)
            {
                var cells = line.Split(';');
                result.Add(new SqlMetaData2(cells[0], cells[1], cells[2], cells[3]));
            }

            return result;
        }
    }
}