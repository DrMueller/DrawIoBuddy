using System.Xml.Linq;
using Mmu.DrawIoBuddy.DomainServices.Infrastructure.Xml.Extensions;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.DrawIoBuddy.DomainServices.Areas.DrawIo.Models
{
    public class MxGeometry : IMxElement
    {
        public int Height { get; }
        public int Width { get; }
        public Maybe<int> X { get; }
        public int Y { get; }

        public MxGeometry(Maybe<int> x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public XObject ToXml()
        {
            var element = new XElement("mxGeometry");
            element.AddAttributeFromMaybe("x", X);
            element.Add(new XAttribute("y", Y));
            element.Add(new XAttribute("width", Width));
            element.Add(new XAttribute("height", Height));
            element.Add(new XAttribute("as", "geometry"));

            return element;
        }
    }
}