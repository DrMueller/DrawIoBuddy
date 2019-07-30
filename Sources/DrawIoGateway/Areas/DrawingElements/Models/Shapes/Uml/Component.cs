using System.Collections.Generic;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.XmlInternals.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.DrawIoBuddy.DrawIoGateway.Areas.DrawingElements.Models.Shapes.Uml
{
    public class Component : ShapeBase
    {
        public Component()
        {
        }

        internal override IReadOnlyCollection<IMxElement> ToMxElements()
        {
            var topLevelCell = MxCell.CreateEmpty(0);

            var secondCell = new MxCell(
                1,
                Maybe.CreateNone<string>(),
                Maybe.CreateNone<string>(),
                Maybe.CreateNone<int>(),
                0,
                Maybe.CreateNone<MxGeometry>());

            var headingCell = new MxCell(
                2,
                "Component",
                "html=1;",
                1,
                1,
                new MxGeometry(210, 210, 180, 90, Maybe.CreateNone<int>(), Maybe.CreateNone<MxPoint>()));

            var valueCell = new MxCell(
                3,
                string.Empty,
                "shape=component;jettyWidth=8;jettyHeight=4;",
                1,
                2,
                new MxGeometry(1, Maybe.CreateNone<int>(), 20, 20, 1, new MxPoint(-27, 7)));

            var result = new List<IMxElement>()
            {
                topLevelCell,
                secondCell,
                headingCell,
                valueCell
            };

            return result;
        }
    }
}