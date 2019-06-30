using System.Xml.Linq;
using Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Xml;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.DrawIoBuddy.Domain.Infrastructure.Xml.Extensions
{
    public static class XmlExtensions
    {
        public static void AddAttributeFromMaybe<T>(this XContainer parent, string name, Maybe<T> value)
        {
            value.Evaluate(val =>
            {
                var tra = val.GetType().Name;
                var attribute = new XAttribute(name, val);
                parent.Add(attribute);
            });
        }

        public static void AddElementFromMaybe<T>(this XContainer parent, string name, Maybe<T> value)
        {
            value.Evaluate(val =>
            {
                var element = new XElement(name, val);
                parent.Add(element);
            });
        }

        public static void AddMxElementFromMaybe(this XContainer parent, Maybe<IMxElement> element)
        {
            element.Evaluate(val =>
            {
                parent.Add(val.ToXml());
            });
        }
    }
}