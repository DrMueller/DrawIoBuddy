using Mmu.DrawIoBuddy.DrawIoGateway.Areas.XmlInternals.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.DrawIoBuddy.DrawIoGateway.Areas.XmlInternals.MxBuilders
{
    internal class MxGeometryBuilder
    {
        private readonly int _height;
        private readonly int _width;
        private Maybe<MxPoint> _point = Maybe.CreateNone<MxPoint>();
        private Maybe<int> _relativeCellId = Maybe.CreateNone<int>();
        private Maybe<int> _x = Maybe.CreateNone<int>();
        private Maybe<int> _y = Maybe.CreateNone<int>();

        public MxGeometryBuilder(int width, int height)
        {
            _width = width;
            _height = height;
        }

        internal static MxGeometryBuilder StartBuilding(int width, int height)
        {
            return new MxGeometryBuilder(width, height);
        }

        internal MxGeometry Build()
        {
            return new MxGeometry(_x, _y, _width, _height, _relativeCellId, _point);
        }

        internal MxGeometryBuilder WithPoint(MxPoint point)
        {
            _point = point;
            return this;
        }

        internal MxGeometryBuilder WithRelativeCellId(int cellId)
        {
            _relativeCellId = cellId;
            return this;
        }

        internal MxGeometryBuilder WithX(int x)
        {
            _x = x;
            return this;
        }

        internal MxGeometryBuilder WithY(int y)
        {
            _y = y;
            return this;
        }
    }
}