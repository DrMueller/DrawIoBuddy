using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.DrawingElements.Models.Shapes;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.Strings.Models;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.XmlInternals.Factories;

namespace Mmu.DrawIoBuddy.DrawIoGateway.Areas.DrawingElements.Services.Implementation
{
    internal class ShapeDisplayService : IShapeDisplayService
    {
        private readonly IXmlDocumentFactory _xmlDocumentFactory;

        public ShapeDisplayService(IXmlDocumentFactory xmlFactory)
        {
            _xmlDocumentFactory = xmlFactory;
        }

        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1119:StatementMustNotUseUnnecessaryParenthesis", Justification = "Actually needed")]
        public DrawIoString CreateDisplayString(IShape shape)
        {
            if (!(shape is ShapeBase shapeBase))
            {
                throw new ArgumentException("Shape has to implment ShapeBase.");
            }

            var mxElements = shapeBase.ToMxElements();
            var xDocument = _xmlDocumentFactory.CreateFromElements(mxElements);
            var xmlString = xDocument.ToString(SaveOptions.DisableFormatting);
            var result = new DrawIoString(xmlString);
            return result;
        }
    }
}