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
                var fistAssignment = ParseAssignment(rawFirstAssignment);
                var secondAssignment = ParseAssignment(rawSecondAssignment);

                if (fistAssignment.FullyContains(secondAssignment) || secondAssignment.FullyContains(fistAssignment))
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
