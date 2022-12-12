using Common;

namespace Day12
{
    internal class Part2 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var area = Part1.ParseArea(lines);
            var shortestPathStepsCount = area.SquaresWithMinimumHeight
                .Select(s => Part1.FindShortestPath(s, area.End))
                .Where(p => p.Count > 0)
                .Min(p => p.Count);

            Console.WriteLine(shortestPathStepsCount);
        }
    }
}
