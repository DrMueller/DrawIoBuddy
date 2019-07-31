using System.Collections.Generic;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.XmlInternals.Models;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.XmlInternals.MxBuilders;

namespace Mmu.DrawIoBuddy.DrawIoGateway.Areas.DrawingElements.Models.Shapes.Uml
{
    public class Component : ShapeBase
    {
        internal override IReadOnlyCollection<IMxElement> ToMxElements()
        {
            var topLevelCell = MxCellBuilder.StartBuilding(0).Build();
            var secondCell = MxCellBuilder.StartBuilding(1).WithParent(0).Build();

            var descriptionCell = MxCellBuilder
                .StartBuilding(2)
                .WithValue("Component")
                .WithStyle("html=1;")
                .WithVertex(1)
                .WithParent(1)
                    .WithGeometry(new MxGeometryBuilder(180, 90)
                    .WithX(210)
                    .WithY(210))
                .Build();

            var componentShapeCell = MxCellBuilder
                .StartBuilding(3)
                .WithValue(string.Empty)
                .WithStyle("shape=component;jettyWidth=8;jettyHeight=4;")
                .WithVertex(1)
                .WithParent(2)
                .WithGeometry(new MxGeometryBuilder(20, 20)
                    .WithRelativeCellId(1)
                    .WithX(1)
                    .WithPoint(new MxPoint(-27, 7)))
                .Build();

            var result = new List<IMxElement>()
            {
                topLevelCell,
                secondCell,
                descriptionCell,
                componentShapeCell
            };

            return result;
        }
    }
}