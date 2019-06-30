using System.Collections.Generic;
using System.Xml.Linq;
using Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Xml;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.DrawIoBuddy.DomainServices.Areas.DrawIo.Services.Implementation
{
    internal class XmlFactory : IXmlFactory
    {
        public XDocument CreateFromElements(IReadOnlyCollection<IMxElement> elements)
        {
            var rootElement = new XElement("root");
            var graphElement = new XElement("mxGraphModel", rootElement);
            elements.ForEach(element => rootElement.Add(element.ToXml()));

            var document = new XDocument(graphElement);
            return document;
        }
    }
}