using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Elements;
using Mmu.DrawIoBuddy.Domain.Areas.StringNative;
using Mmu.DrawIoBuddy.DomainServices.Areas.DrawIo.Services;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.DrawingElements.Models.Shapes;

namespace Mmu.DrawIoBuddy.DrawIoGateway.Areas.DrawingElements.Services.Implementation
{
    internal class ShapeDisplayService : IShapeDisplayService
    {
        private readonly IXmlFactory _xmlFactory;

        public ShapeDisplayService(IXmlFactory xmlFactory)
        {
            _xmlFactory = xmlFactory;
        }

        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1119:StatementMustNotUseUnnecessaryParenthesis", Justification = "Actually needed")]
        public DrawIoString CreateDisplayString(IShape shape)
        {
            if (!(shape is ShapeBase shapeBase))
            {
                throw new ArgumentException("Shape has to implment ShapeBase.");
            }

            var mxElements = shapeBase.ToMxElements();
            var xDocument = _xmlFactory.CreateFromElements(mxElements);
            var xmlString = xDocument.ToString(SaveOptions.DisableFormatting);
            var result = new DrawIoString(xmlString);
            return result;
        }
    }
}