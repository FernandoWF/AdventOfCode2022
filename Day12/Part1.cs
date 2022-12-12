using Common;

namespace Day12
{
    internal class Part1 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var area = ParseArea(lines);
            var shortestPath = FindShortestPath(area.Start, area.End);

            Console.WriteLine(shortestPath.Count);
        }

        public static Area ParseArea(string[] lines)
        {
            var width = lines.First().Length;
            var height = lines.Length;
            var area = new Area(width, height);

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    area.SetSquare(lines[y][x], x, y);
                }
            }

            return area;
        }

        public static IReadOnlyList<Square> FindShortestPath(Square startSquare, Square endSquare)
        {
            var previousSquareFromCurrentSquare = new Dictionary<Square, Square>();
            var queue = new Queue<Square>();
            queue.Enqueue(startSquare);

            while (queue.Count > 0)
            {
                var square = queue.Dequeue();

                var topSquare = square.GetTopSquare()!;
                if (square.CanTravelToTopSquare() && !previousSquareFromCurrentSquare.ContainsKey(topSquare))
                {
                    previousSquareFromCurrentSquare[topSquare] = square;
                    queue.Enqueue(topSquare);
                }

                var bottomSquare = square.GetBottomSquare()!;
                if (square.CanTravelToBottomSquare() && !previousSquareFromCurrentSquare.ContainsKey(bottomSquare))
                {
                    previousSquareFromCurrentSquare[bottomSquare] = square;
                    queue.Enqueue(bottomSquare);
                }

                var leftSquare = square.GetLeftSquare()!;
                if (square.CanTravelToLeftSquare() && !previousSquareFromCurrentSquare.ContainsKey(leftSquare))
                {
                    previousSquareFromCurrentSquare[leftSquare] = square;
                    queue.Enqueue(leftSquare);
                }

                var rightSquare = square.GetRightSquare()!;
                if (square.CanTravelToRightSquare() && !previousSquareFromCurrentSquare.ContainsKey(rightSquare))
                {
                    previousSquareFromCurrentSquare[rightSquare] = square;
                    queue.Enqueue(rightSquare);
                }
            }

            var path = new List<Square>();
            var pathExists = previousSquareFromCurrentSquare.ContainsKey(endSquare);
            if (!pathExists)
            {
                return path;
            }

            var currentSquare = endSquare;
            while (currentSquare != startSquare)
            {
                path.Add(currentSquare);
                currentSquare = previousSquareFromCurrentSquare[currentSquare];
            };

            path.Reverse();

            return path;
        }
    }
}
