using System.Linq;
using Mmu.DrawIoBuddy.Domain.Areas.DrawingElements.Services;
using Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Elements.MetaData;
using Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Elements.Uml;
using Mmu.DrawIoBuddy.DomainServices.Areas.Factories;

namespace Mmu.DrawIoBuddy.WpfUI.Areas.Uml.ClassFromMetaData.ViewServices.Implementation
{
    public class ClassTransformatorViewService : IClassTransformatorViewService
    {
        private readonly IDrawIoStringFactory _drawIoStringFactory;
        private readonly ISqlMetaDataFactory _sqlMetaDataFactory;

        public ClassTransformatorViewService(
            ISqlMetaDataFactory sqlMetaDataFactory,
            IDrawIoStringFactory drawIoStringFactory)
        {
            _sqlMetaDataFactory = sqlMetaDataFactory;
            _drawIoStringFactory = drawIoStringFactory;
        }

        public string Transform(string metaData)
        {
            var sqlMetaData = _sqlMetaDataFactory.Parse(metaData).ToArray();
            var properties = sqlMetaData.Select(sql => "+ " + sql.ColumnName + " - " + sql.ColumnType + " (" + sql.ColumnSize + ")").ToList();

            var umlClass2 = new UmlClass2(
                new Position(0, 0),
                sqlMetaData.First().TableName,
                properties);

            var drawIoString = _drawIoStringFactory.CreateFromElement(umlClass2);
            return drawIoString.DecodeString();
        }
    }
}