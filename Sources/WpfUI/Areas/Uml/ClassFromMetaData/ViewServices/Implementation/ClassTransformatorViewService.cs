using System.Collections.Generic;
using System.Linq;
using Mmu.DrawIoBuddy.DomainServices.Areas.DrawIo.Model;
using Mmu.DrawIoBuddy.DomainServices.Areas.DrawIo.Models;
using Mmu.DrawIoBuddy.DomainServices.Areas.DrawIo.Services;
using Mmu.DrawIoBuddy.DomainServices.Areas.Factories;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.DrawIoBuddy.WpfUI.Areas.Uml.ClassFromMetaData.ViewServices.Implementation
{
    public class ClassTransformatorViewService : IClassTransformatorViewService
    {
        private readonly ISqlMetaDataFactory _sqlMetaDataFactory;
        private readonly IXmlFactory _xmlFactory;
        private readonly IStringAdapter _stringAdapter;

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

            var cells = new List<MxCell>
            {
                new MxCell(
                    0,
                    Maybe.CreateNone<string>(),
                    Maybe.CreateNone<string>(),
                    Maybe.CreateNone<int>(),
                    Maybe.CreateNone<int>(),
                    Maybe.CreateNone<MxGeometry>()),

                new MxCell(
                    1,
                    Maybe.CreateNone<string>(),
                    Maybe.CreateNone<string>(),
                    Maybe.CreateNone<int>(),
                    0,
                    Maybe.CreateNone<MxGeometry>()),

                new MxCell(
                    2,
                    sqlMetaData.First().TableName,
                    "swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=26;fillColor=none;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;",
                    1,
                    1,
                    new MxGeometry(350, 710, 140, 52))
            };

            for (var i = 0; i < sqlMetaData.Length; i++)
            {
                var entry = sqlMetaData[i];
                var yAxis = 710 + ((i + 1) * 26);

                var cell = new MxCell(
                    i + 3,
                    entry.ColumnName,
                    "text;strokeColor=none;fillColor=none;align=left;verticalAlign=top;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;",
                    1,
                    2,
                    new MxGeometry(230, yAxis, 140, 26));

                cells.Add(cell);
            }

            var xmlString = _xmlFactory.CreateDrawIoXmlString(cells.ToArray());
            var result = _stringAdapter.EncodeToDrawIoString(xmlString);
            return result;
        }
    }
}