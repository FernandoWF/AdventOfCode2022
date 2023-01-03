using System.Drawing;
using Common;

namespace Day14
{
    internal class Part1 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var rockPaths = lines.Select(ParsePath).ToList();
            var rocks = rockPaths.SelectMany(GetAllRocksFromPath).ToList();
            var occupiedPositions = new HashSet<Point>(rocks);

            var sandPouringOrigin = new Point(500, 0);
            var pouredSandUnits = 0;
            Point? restPosition;

            do
            {
                restPosition = MoveSand(sandPouringOrigin, occupiedPositions);
                pouredSandUnits++;
            }
            while (restPosition != null);

            var restedSandUnits = pouredSandUnits - 1;
            Console.WriteLine(restedSandUnits);
        }

        private static Point[] ParsePath(string line)
        {
            return line
                .Split(" -> ")
                .Select(rawPair =>
                {
                    var separatorPosition = rawPair.IndexOf(',');
                    var xCoordinate = int.Parse(rawPair[..separatorPosition]);
                    var yCoordinate = int.Parse(rawPair[(separatorPosition + 1)..]);

                    return new Point(xCoordinate, yCoordinate);
                })
                .ToArray();
        }

        private static HashSet<Point> GetAllRocksFromPath(Point[] path)
        {
            var rocks = new HashSet<Point>();

            for (var i = 1; i < path.Length; i++)
            {
                var previousRock = path[i - 1];
                var currentRock = path[i];

                if (previousRock.X == currentRock.X)
                {
                    var biggerY = Math.Max(previousRock.Y, currentRock.Y);
                    var smallerY = Math.Min(previousRock.Y, currentRock.Y);

                    for (var y = smallerY; y <= biggerY; y++)
                    {
                        rocks.Add(new Point(currentRock.X, y));
                    }
                }
                else if (previousRock.Y == currentRock.Y)
                {
                    var biggerX = Math.Max(previousRock.X, currentRock.X);
                    var smallerX = Math.Min(previousRock.X, currentRock.X);

                    for (var x = smallerX; x <= biggerX; x++)
                    {
                        rocks.Add(new Point(x, currentRock.Y));
                    }
                }
                else
                {
                    throw new ArgumentException("Specified path is invalid", nameof(path));
                }
            }

            return rocks;
        }

        private static Point? MoveSand(Point startingPosition, ISet<Point> occupiedPositions)
        {
            var maximumY = occupiedPositions.Max(p => p.Y);
            var restPosition = startingPosition;

            while (restPosition.Y <= maximumY)
            {
                var downPosition = new Point(restPosition.X, restPosition.Y + 1);
                var leftDiagonalPosition = new Point(restPosition.X - 1, restPosition.Y + 1);
                var rightDiagonalPosition = new Point(restPosition.X + 1, restPosition.Y + 1);

                if (occupiedPositions.Contains(downPosition))
                {
                    if (occupiedPositions.Contains(leftDiagonalPosition))
                    {
                        if (occupiedPositions.Contains(rightDiagonalPosition))
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

            return null;
        }
    }
}
