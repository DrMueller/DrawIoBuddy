using System.Xml.Linq;
using Mmu.DrawIoBuddy.DrawIoGateway.Infrastructure.Xml.Extensions;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.DrawIoBuddy.DrawIoGateway.Areas.XmlInternals.Models
{
    internal class MxCell : IMxElement
    {
        private readonly Maybe<MxGeometry> _geometry;
        private readonly int _id;
        private readonly Maybe<int> _parent;
        private readonly Maybe<string> _style;
        private readonly Maybe<string> _value;
        private readonly Maybe<int> _vertex;

        public MxCell(
            int id,
            Maybe<string> value,
            Maybe<string> style,
            Maybe<int> vertex,
            Maybe<int> parent,
            Maybe<MxGeometry> geometry)
        {
            _id = id;
            _value = value;
            _style = style;
            _vertex = vertex;
            _parent = parent;
            _geometry = geometry;
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
            element.Add(new XAttribute("id", _id));
            element.AddAttributeFromMaybe("value", _value);
            element.AddAttributeFromMaybe("style", _style);
            element.AddAttributeFromMaybe("vertex", _vertex);
            element.AddAttributeFromMaybe("parent", _parent);
            _geometry.Evaluate(geo => element.Add(geo.ToXml()));

            return element;
        }
    }
}