using System.Collections.Generic;
using System.Xml.Linq;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.XmlInternals.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.DrawIoBuddy.DrawIoGateway.Areas.XmlInternals.Factories.Implementation
{
    internal class XmlDocumentFactory : IXmlDocumentFactory
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