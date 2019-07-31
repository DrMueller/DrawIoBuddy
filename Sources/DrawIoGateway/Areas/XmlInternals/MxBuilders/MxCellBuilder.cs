using Mmu.DrawIoBuddy.DrawIoGateway.Areas.XmlInternals.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.DrawIoBuddy.DrawIoGateway.Areas.XmlInternals.MxBuilders
{
    internal class MxCellBuilder
    {
        private readonly int _id;
        private Maybe<MxGeometryBuilder> _geometryBuilder = Maybe.CreateNone<MxGeometryBuilder>();
        private Maybe<int> _parent = Maybe.CreateNone<int>();
        private Maybe<string> _style = Maybe.CreateNone<string>();
        private Maybe<string> _value = Maybe.CreateNone<string>();
        private Maybe<int> _vertex = Maybe.CreateNone<int>();

        public MxCellBuilder(int id)
        {
            _id = id;
        }

        internal static MxCellBuilder StartBuilding(int id)
        {
            return new MxCellBuilder(id);
        }

        internal MxCell Build()
        {
            var geometry = _geometryBuilder.Evaluate<Maybe<MxGeometry>>(
                builder => builder.Build(),
                () => Maybe.CreateNone<MxGeometry>());

            return new MxCell(_id, _value, _style, _vertex, _parent, geometry);
        }

        internal MxCellBuilder WithGeometry(MxGeometryBuilder builder)
        {
            _geometryBuilder = builder;
            return this;
        }

        internal MxCellBuilder WithParent(int parent)
        {
            _parent = parent;
            return this;
        }

        internal MxCellBuilder WithStyle(string style)
        {
            _style = style;
            return this;
        }

        internal MxCellBuilder WithValue(string value)
        {
            _value = value;
            return this;
        }

        internal MxCellBuilder WithVertex(int vertex)
        {
            _vertex = vertex;
            return this;
        }
    }
}