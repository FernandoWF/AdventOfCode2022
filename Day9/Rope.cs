using System.Drawing;

namespace Day9
{
    internal class Rope
    {
        private Point headPosition = Point.Empty;
        private Point tailPosition = Point.Empty;

        public ISet<Point> PositionsTailVisited { get; } = new HashSet<Point> { Point.Empty };

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

                headPosition.Offset(horizontalOffset, verticalOffset);
                UpdateTailPosition();
            }
        }

        private void UpdateTailPosition()
        {
            var offset = headPosition - (Size)tailPosition;
            var absoluteOffset = new Point(Math.Abs(offset.X), Math.Abs(offset.Y));
            var signOffset = new Point(Math.Sign(offset.X), Math.Sign(offset.Y));

            if (absoluteOffset.X <= 1 && absoluteOffset.Y <= 1) { return; }

            if ((absoluteOffset.X == 2 && absoluteOffset.Y == 2)
                || absoluteOffset.X > 2
                || absoluteOffset.Y > 2)
            {
                throw new InvalidOperationException("Tail is too far from head");
            }

            if (absoluteOffset.X == 2)
            {
                if (offset.Y == 0)
                {
                    tailPosition.Offset(signOffset.X, 0);
                }
                else
                {
                    tailPosition.Offset(signOffset);
                }
            }
            else
            {
                if (offset.X == 0)
                {
                    tailPosition.Offset(0, signOffset.Y);
                }
                else
                {
                    tailPosition.Offset(signOffset);
                }
            }

            PositionsTailVisited.Add(tailPosition);
        }
    }
}
