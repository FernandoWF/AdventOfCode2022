using System.Diagnostics;
using System.Drawing;
using Common;

namespace Day14
{
    internal class Part2 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var rockPaths = lines.Select(Part1.ParsePath).ToList();
            var rocks = rockPaths.SelectMany(Part1.GetAllRocksFromPath).ToList();
            var occupiedPositions = new HashSet<Point>(rocks);
            var maximumRockY = occupiedPositions.Max(p => p.Y);

            var restedSandUnits = 0;
            Point? restPosition;

            do
            {
                restPosition = MoveSand(Part1.SandPouringOrigin, occupiedPositions, maximumRockY);
                restedSandUnits++;
            }
            while (restPosition != Part1.SandPouringOrigin);

            Console.WriteLine(restedSandUnits);
        }

        private static Point MoveSand(Point startingPosition, ISet<Point> occupiedPositions, int maximumRockY)
        {
            var floorY = maximumRockY + 2;
            var restPosition = startingPosition;

            while (true)
            {
                var downPosition = new Point(restPosition.X, restPosition.Y + 1);
                var leftDiagonalPosition = new Point(restPosition.X - 1, restPosition.Y + 1);
                var rightDiagonalPosition = new Point(restPosition.X + 1, restPosition.Y + 1);

                if (occupiedPositions.Contains(downPosition) || downPosition.Y == floorY)
                {
                    if (occupiedPositions.Contains(leftDiagonalPosition) || leftDiagonalPosition.Y == floorY)
                    {
                        if (occupiedPositions.Contains(rightDiagonalPosition) || rightDiagonalPosition.Y == floorY)
                        {
                            occupiedPositions.Add(restPosition);

                            return restPosition;
                        }
                        else
                        {
                            restPosition = rightDiagonalPosition;
                        }
                    }
                    else
                    {
                        restPosition = leftDiagonalPosition;
                    }
                }
                else
                {
                    restPosition = downPosition;
                }
            }

            throw new UnreachableException("Loop ended without defining a rest position");
        }
    }
}
