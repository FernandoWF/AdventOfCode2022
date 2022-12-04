using Common;

namespace Day4
{
    internal class Part1 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var pairsWithOneFullyContainedAssignment = 0;

            foreach (var line in lines)
            {
                (var rawFirstAssignment, var rawSecondAssignment) = SeparateRawAssignments(line);
                var firstAssignment = ParseAssignment(rawFirstAssignment);
                var secondAssignment = ParseAssignment(rawSecondAssignment);

                if (firstAssignment.FullyContains(secondAssignment) || secondAssignment.FullyContains(firstAssignment))
                {
                    pairsWithOneFullyContainedAssignment++;
                }
            }

            Console.WriteLine(pairsWithOneFullyContainedAssignment);
        }

        public static (string rawFirstAssignment, string rawSecondAssignment) SeparateRawAssignments(string line)
        {
            var separatorPosition = line.IndexOf(',');
            var firstAssignment = line[..separatorPosition];
            var secondAssignment = line[(separatorPosition + 1)..];

            return (firstAssignment, secondAssignment);
        }

        public static Assignment ParseAssignment(string rawAssignment)
        {
            var separatorPosition = rawAssignment.IndexOf('-');
            var startingSection = rawAssignment[..separatorPosition];
            var endingSection = rawAssignment[(separatorPosition + 1)..];

            return new Assignment(int.Parse(startingSection), int.Parse(endingSection));
        }
    }
}
