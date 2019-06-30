using System.Collections.Generic;
using Mmu.DrawIoBuddy.Domain;
using Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Xml;
using Mmu.DrawIoBuddy.DomainServices.Areas.DrawIo.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.DrawIoBuddy.DomainServices.Areas.Adapters.Implementation
{
    public class SqlMetaDataToClassAdapter : ISqlMetaDataToClassAdapter
    {
        private readonly IXmlFactory _xmlFactory;

        public SqlMetaDataToClassAdapter(IXmlFactory xmlFactory)
        {
            _xmlFactory = xmlFactory;
        }

        public string Adapt(IReadOnlyCollection<SqlMetaData> metaData)
        {
            const string DefaultStyle = "swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=26;fillColor=none;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;";

            var cell1 = new MxCell(
                0,
                Maybe.CreateNone<string>(),
                Maybe.CreateNone<string>(),
                Maybe.CreateNone<int>(),
                Maybe.CreateNone<int>(),
                Maybe.CreateNone<MxGeometry>());

            var cell2 = new MxCell(
                1,
                Maybe.CreateNone<string>(),
                Maybe.CreateNone<string>(),
                Maybe.CreateNone<int>(),
                0,
                Maybe.CreateNone<MxGeometry>());

            var cell3 = new MxCell(
                2,
                "Hello World",
                DefaultStyle,
                1,
                1,
               new MxGeometry(230, 230, 230, 104));

            var cells = new MxCell[]
            {
                cell1,
                cell2,
                cell3
            };

            var str = _xmlFactory.CreateDrawIoXmlString(cells);
            return str;
        }
    }
}