using System.Xml.Linq;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.XmlInternals.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.DrawIoBuddy.DrawIoGateway.Infrastructure.Xml.Extensions
{
    internal static class XmlExtensions
    {
        internal static void AddAttributeFromMaybe<T>(this XContainer parent, string name, Maybe<T> value)
        {
            value.Evaluate(val =>
            {
                var tra = val.GetType().Name;
                var attribute = new XAttribute(name, val);
                parent.Add(attribute);
            });
        }

        internal static void AddElementFromMaybe<T>(this XContainer parent, string name, Maybe<T> value)
        {
            value.Evaluate(val =>
            {
                var element = new XElement(name, val);
                parent.Add(element);
            });
        }

        internal static void AddMxElementFromMaybe(this XContainer parent, Maybe<IMxElement> element)
        {
            element.Evaluate(val =>
            {
                parent.Add(val.ToXml());
            });
        }
    }
}