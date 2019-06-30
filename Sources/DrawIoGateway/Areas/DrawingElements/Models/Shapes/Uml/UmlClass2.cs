using System.Collections.Generic;
using System.Linq;
using Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Elements.MetaData;
using Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Xml;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.DrawingElements.Models.Shapes;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Elements.Uml
{
    public class UmlClass2 : DrawIoShapeBase
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
                HeadingText,
                "swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=26;fillColor=none;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;",
                1,
                1,
                new MxGeometry(_position.X, _position.Y, 140, 52));

            var propertyCells = new List<MxCell>();

            for (var i = 0; i < Properties.Count; i++)
            {
                var yAxis = _position.Y + ((i + 1) * 26);

                var cell = new MxCell(
                    i + 3,
                    Properties.ElementAt(i),
                    "text;strokeColor=none;fillColor=none;align=left;verticalAlign=top;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;",
                    1,
                    2,
                    new MxGeometry(230, yAxis, 140, 26));

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