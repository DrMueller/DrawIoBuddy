using System.Xml.Linq;
using Mmu.DrawIoBuddy.DomainServices.Areas.DrawIo.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.DrawIoBuddy.DomainServices.Areas.DrawIo.Services.Implementation
{
    public class XmlFactory : IXmlFactory
    {
        public string CreateDrawIoXmlString(params IMxElement[] elements)
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