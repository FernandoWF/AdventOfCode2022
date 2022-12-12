using System.Drawing;

namespace Day12
{
    internal class Square : IEquatable<Square>
    {
        private readonly Area area;

        public Point Position { get; }
        public int Height { get; }

        public Square(Point position, int height, Area area)
        {
            Position = position;
            Height = height;
            this.area = area;
        }

        public Square? GetTopSquare() => area.GetSquare(Point.Add(Position, new Size(0, -1)));
        public Square? GetBottomSquare() => area.GetSquare(Point.Add(Position, new Size(0, 1)));
        public Square? GetLeftSquare() => area.GetSquare(Point.Add(Position, new Size(-1, 0)));
        public Square? GetRightSquare() => area.GetSquare(Point.Add(Position, new Size(1, 0)));

        public bool CanTravelToTopSquare() => CanTravelToSquare(GetTopSquare());
        public bool CanTravelToBottomSquare() => CanTravelToSquare(GetBottomSquare());
        public bool CanTravelToLeftSquare() => CanTravelToSquare(GetLeftSquare());
        public bool CanTravelToRightSquare() => CanTravelToSquare(GetRightSquare());

        private bool CanTravelToSquare(Square? otherSquare)
        {
            return otherSquare != null && otherSquare.Height - Height <= 1;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Square square)
            {
                return Equals(square);
            }

            return false;
        }

        public bool Equals(Square? other) => Equals(Position, other?.Position) && Equals(Height, other?.Height);
        public override int GetHashCode() => HashCode.Combine(Position, Height);

        public static bool operator ==(Square? x, Square? y) => Equals(x, y);
        public static bool operator !=(Square? x, Square? y) => !Equals(x, y);
    }
}
