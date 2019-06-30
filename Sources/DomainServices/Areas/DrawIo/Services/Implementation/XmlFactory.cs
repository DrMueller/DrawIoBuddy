using System.Collections.Generic;
using System.Xml.Linq;
using Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Xml;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.DrawIoBuddy.DomainServices.Areas.DrawIo.Services.Implementation
{
    public class XmlFactory : IXmlFactory
    {
        public string CreateDrawIoXmlString(IReadOnlyCollection<IMxElement> elements)
        {
            var rootElement = new XElement("root");
            var graphElement = new XElement("mxGraphModel", rootElement);
            var document = new XDocument(graphElement);
            elements.ForEach(element => rootElement.Add(element.ToXml()));

            var xmlString = document.ToString(SaveOptions.DisableFormatting);

            return xmlString;
        }
    }
}