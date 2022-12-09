using System.Drawing;

namespace Day9
{
    internal class Rope
    {
        private readonly List<Point> knots = new();

        public ISet<Point> PositionsTailVisited { get; } = new HashSet<Point> { Point.Empty };

        public Rope(int lenght = 2)
        {
            if (lenght < 2) { throw new ArgumentOutOfRangeException(nameof(lenght)); }

            for (var i = 0; i < lenght; i++)
            {
                knots.Add(Point.Empty);
            }
        }

        public void MoveHead(Direction direction, int steps)
        {
            for (var i = 0; i < steps; i++)
            {
                var horizontalOffset = 0;
                var verticalOffset = 0;

                switch (direction)
                {
                    case Direction.Up:
                        verticalOffset = -1;
                        break;

                    case Direction.Down:
                        verticalOffset = 1;
                        break;

                    case Direction.Left:
                        horizontalOffset = -1;
                        break;

                    case Direction.Right:
                        horizontalOffset = 1;
                        break;
                }

                var headPosition = knots.First();
                headPosition.Offset(horizontalOffset, verticalOffset);
                knots[0] = headPosition;
                UpdateKnotPosition(1);
            }
        }

        private void UpdateKnotPosition(int knotIndex)
        {
            var previousKnotPosition = knots[knotIndex - 1];
            var knotPosition = knots[knotIndex];

            var offset = previousKnotPosition - (Size)knotPosition;
            var absoluteOffset = new Point(Math.Abs(offset.X), Math.Abs(offset.Y));
            var signOffset = new Point(Math.Sign(offset.X), Math.Sign(offset.Y));

            if (absoluteOffset.X <= 1 && absoluteOffset.Y <= 1) { return; }

            if (absoluteOffset.X > 2 || absoluteOffset.Y > 2)
            {
                throw new InvalidOperationException("Tail is too far from head");
            }

            if (absoluteOffset.X == 2)
            {
                if (offset.Y == 0)
                {
                    knotPosition.Offset(signOffset.X, 0);
                }
                else
                {
                    knotPosition.Offset(signOffset);
                }
            }
            else
            {
                if (offset.X == 0)
                {
                    knotPosition.Offset(0, signOffset.Y);
                }
                else
                {
                    knotPosition.Offset(signOffset);
                }
            }

            knots[knotIndex] = knotPosition;

            if (knotIndex == knots.Count - 1)
            {
                PositionsTailVisited.Add(knotPosition);
            }
            else
            {
                UpdateKnotPosition(knotIndex + 1);
            }
        }
    }
}
