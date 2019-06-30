namespace Mmu.DrawIoBuddy.Domain.Areas.DrawIo.Elements.MetaData
{
    public class Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}