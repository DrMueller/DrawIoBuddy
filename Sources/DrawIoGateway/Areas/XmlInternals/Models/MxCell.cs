using System.Xml.Linq;
using Mmu.DrawIoBuddy.Domain.Infrastructure.Xml.Extensions;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Xml
{
    internal class MxCell : IMxElement
    {
        public Maybe<MxGeometry> Geometry { get; }
        public int Id { get; }
        public Maybe<int> Parent { get; }
        public Maybe<string> Style { get; }
        public Maybe<string> Value { get; }
        public Maybe<int> Vertex { get; }

        public MxCell(
            int id,
            Maybe<string> value,
            Maybe<string> style,
            Maybe<int> vertex,
            Maybe<int> parent,
            Maybe<MxGeometry> geometry)
        {
            Id = id;
            Value = value;
            Style = style;
            Vertex = vertex;
            Parent = parent;
            Geometry = geometry;
        }

        public static MxCell CreateEmpty(int id)
        {
            return new MxCell(
                id,
                Maybe.CreateNone<string>(),
                Maybe.CreateNone<string>(),
                Maybe.CreateNone<int>(),
                Maybe.CreateNone<int>(),
                Maybe.CreateNone<MxGeometry>());
        }

        public XObject ToXml()
        {
            var element = new XElement("mxCell");
            element.Add(new XAttribute("id", Id));
            element.AddAttributeFromMaybe("value", Value);
            element.AddAttributeFromMaybe("style", Style);
            element.AddAttributeFromMaybe("vertex", Vertex);
            element.AddAttributeFromMaybe("parent", Parent);
            Geometry.Evaluate(geo => element.Add(geo.ToXml()));

            return element;
        }
    }
}