using System.Linq;
using Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Elements.MetaData;
using Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Elements.Uml;
using Mmu.DrawIoBuddy.DomainServices.Areas.DrawIo.Services;
using Mmu.DrawIoBuddy.DomainServices.Areas.Factories;

namespace Mmu.DrawIoBuddy.WpfUI.Areas.Uml.ClassFromMetaData.ViewServices.Implementation
{
    public class ClassTransformatorViewService : IClassTransformatorViewService
    {
        private readonly ISqlMetaDataFactory _sqlMetaDataFactory;
        private readonly IStringAdapter _stringAdapter;
        private readonly IXmlFactory _xmlFactory;

        public ClassTransformatorViewService(
            ISqlMetaDataFactory sqlMetaDataFactory,
            IXmlFactory xmlFactory,
            IStringAdapter stringAdapter)
        {
            _sqlMetaDataFactory = sqlMetaDataFactory;
            _xmlFactory = xmlFactory;
            _stringAdapter = stringAdapter;
        }

        public string Transform(string metaData)
        {
            var sqlMetaData = _sqlMetaDataFactory.Parse(metaData).ToArray();
            var properties = sqlMetaData.Select(sql => "+ " + sql.ColumnName + " - " + sql.ColumnType + " (" + sql.ColumnSize + ")").ToList();

            var umlClass2 = new UmlClass2(
                new Position(0, 0),
                sqlMetaData.First().TableName,
                properties);

            var mxElements = umlClass2.ToMxElements();
            var xmlString = _xmlFactory.CreateDrawIoXmlString(mxElements);
            var result = _stringAdapter.EncodeToDrawIoString(xmlString);
            return result;
        }
    }
}