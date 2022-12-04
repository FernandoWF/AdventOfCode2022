using Common;

namespace Day4
{
    internal class Part2 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var pairsWithOverlaps = 0;

            foreach (var line in lines)
            {
                (var rawFirstAssignment, var rawSecondAssignment) = Part1.SeparateRawAssignments(line);
                var firstAssignment = Part1.ParseAssignment(rawFirstAssignment);
                var secondAssignment = Part1.ParseAssignment(rawSecondAssignment);

                if (firstAssignment.Overlaps(secondAssignment))
                {
                    pairsWithOverlaps++;
                }
            }

            Console.WriteLine(pairsWithOverlaps);
        }
    }
}
