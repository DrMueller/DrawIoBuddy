using System.Collections.Generic;
using System.Linq;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.DrawingElements.Models.MetaData;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.XmlInternals.Models;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.XmlInternals.MxBuilders;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.DrawIoBuddy.DrawIoGateway.Areas.DrawingElements.Models.Shapes.Uml
{
    public class UmlClass2 : ShapeBase
    {
        private readonly Position _position;

        public string HeadingText { get; }
        public IReadOnlyCollection<string> Properties { get; }

        public UmlClass2(
            Position position,
            string headingText,
            IReadOnlyCollection<string> properties)
        {
            Guard.ObjectNotNull(() => position);
            Guard.ObjectNotNull(() => properties);

            _position = position;
            HeadingText = headingText;
            Properties = properties;
        }

        internal override IReadOnlyCollection<IMxElement> ToMxElements()
        {
            var topLevelCell = MxCellBuilder.StartBuilding(0).Build();
            var secondCell = MxCellBuilder.StartBuilding(1).WithParent(0).Build();
            var headingCell = MxCellBuilder.StartBuilding(2)
                .WithValue(HeadingText)
                .WithStyle("swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=26;fillColor=none;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;")
                .WithParent(1)
                .WithVertex(1)
                .WithGeometry(
                    MxGeometryBuilder.StartBuilding(140, 52)
                    .WithY(_position.Y)
                    .WithX(_position.X))
                .Build();

            var propertyCells = new List<MxCell>();

            for (var i = 0; i < Properties.Count; i++)
            {
                var yAxis = _position.Y + ((i + 1) * 26);

                var cell = MxCellBuilder.StartBuilding(i + 3)
                    .WithValue(Properties.ElementAt(i))
                    .WithStyle("text;strokeColor=none;fillColor=none;align=left;verticalAlign=top;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;")
                    .WithParent(2)
                    .WithVertex(1)
                    .WithGeometry(
                        new MxGeometryBuilder(140, 26)
                        .WithX(230)
                        .WithY(yAxis))
                    .Build();

                propertyCells.Add(cell);
            }

            var result = new List<IMxElement>()
            {
                topLevelCell,
                secondCell,
                headingCell
            }.Concat(propertyCells).ToList();

            return result;
        }
    }
}