using System.Linq;
using Mmu.DrawIoBuddy.DomainServices.Areas.SqlMetaData.Services.Servants;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.DrawingElements.Models.MetaData;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.DrawingElements.Models.Shapes.Uml;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.DrawingElements.Services;

namespace Mmu.DrawIoBuddy.DomainServices.Areas.SqlMetaData.Services.Implementation
{
    public class SqlMetaDataTransformer : ISqlMetaDataTransformer
    {
        private readonly ISqlMetaDataFactory _sqlMetaDataFactory;
        private readonly IShapeDisplayService _shapeDisplayService;

        public SqlMetaDataTransformer(
            ISqlMetaDataFactory sqlMetaDataFactory,
            IShapeDisplayService shapeDisplayService)
        {
            _sqlMetaDataFactory = sqlMetaDataFactory;
            _shapeDisplayService = shapeDisplayService;
        }

        public string Transform(string sqlMetaDataString)
        {
            var sqlMetaData = _sqlMetaDataFactory.Parse(sqlMetaDataString);
            var properties = sqlMetaData.Select(sql => "+ " + sql.ColumnName + " - " + sql.ColumnType + " (" + sql.ColumnSize + ")").ToList();

            var umlClass2 = new UmlClass2(
                new Position(0, 0),
                sqlMetaData.First().TableName,
                properties);

            var drawIoString = _shapeDisplayService.CreateDisplayString(umlClass2);
            return drawIoString.EncodeString();
        }
    }
}