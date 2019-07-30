using System.Xml.Linq;
using Mmu.DrawIoBuddy.DrawIoGateway.Infrastructure.Xml.Extensions;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.DrawIoBuddy.DrawIoGateway.Areas.XmlInternals.Models
{
    internal class MxGeometry : IMxElement
    {
        private readonly int _height;
        private readonly Maybe<int> _relativeCellId;
        private readonly Maybe<MxPoint> _point;
        private readonly int _width;
        private readonly Maybe<int> _x;
        private readonly Maybe<int> _y;

        public MxGeometry(Maybe<int> x, Maybe<int> y, int width, int height, Maybe<int> relativeCellId, Maybe<MxPoint> point)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _relativeCellId = relativeCellId;
            _point = point;
        }

        public XObject ToXml()
        {
            var element = new XElement("mxGeometry");
            element.AddAttributeFromMaybe("x", _x);
            element.AddAttributeFromMaybe("y", _y);
            element.Add(new XAttribute("width", _width));
            element.Add(new XAttribute("height", _height));
            element.Add(new XAttribute("as", "geometry"));
            element.AddAttributeFromMaybe("relative", _relativeCellId);
            element.AddMxElementFromMaybe(_point);

            return element;
        }
    }
}