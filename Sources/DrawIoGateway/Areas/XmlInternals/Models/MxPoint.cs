using System.Xml.Linq;

namespace Mmu.DrawIoBuddy.DrawIoGateway.Areas.XmlInternals.Models
{
    internal class MxPoint : IMxElement
    {
        private readonly int _x;
        private readonly int _y;

        public MxPoint(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public XObject ToXml()
        {
            var element = new XElement("mxPoint");
            element.Add(new XAttribute("x", _x));
            element.Add(new XAttribute("y", _y));
            element.Add(new XAttribute("as", "offset"));

            return element;
        }
    }
}