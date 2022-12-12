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
            var squareToPreviousSquare = new Dictionary<Square, Square>();
            var queue = new Queue<Square>();
            queue.Enqueue(startSquare);

            while (queue.Count > 0)
            {
                var square = queue.Dequeue();

                var topSquare = square.GetTopSquare()!;
                if (square.CanTravelToTopSquare() && !squareToPreviousSquare.ContainsKey(topSquare))
                {
                    squareToPreviousSquare[topSquare] = square;
                    queue.Enqueue(topSquare);
                }

                var bottomSquare = square.GetBottomSquare()!;
                if (square.CanTravelToBottomSquare() && !squareToPreviousSquare.ContainsKey(bottomSquare))
                {
                    squareToPreviousSquare[bottomSquare] = square;
                    queue.Enqueue(bottomSquare);
                }

                var leftSquare = square.GetLeftSquare()!;
                if (square.CanTravelToLeftSquare() && !squareToPreviousSquare.ContainsKey(leftSquare))
                {
                    squareToPreviousSquare[leftSquare] = square;
                    queue.Enqueue(leftSquare);
                }

                var rightSquare = square.GetRightSquare()!;
                if (square.CanTravelToRightSquare() && !squareToPreviousSquare.ContainsKey(rightSquare))
                {
                    squareToPreviousSquare[rightSquare] = square;
                    queue.Enqueue(rightSquare);
                }
            }

            var path = new List<Square>();
            var currentSquare = endSquare;

            while (currentSquare != startSquare)
            {
                path.Add(currentSquare);
                currentSquare = squareToPreviousSquare[currentSquare];
            };

            path.Reverse();

            return path;
        }
    }
}
