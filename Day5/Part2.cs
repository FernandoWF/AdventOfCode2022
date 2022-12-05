using Common;

namespace Day5
{
    internal class Part2 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var separator = Part1.GetIndexOfFirstEmptyLine(lines);

            var crateStackLines = lines[..(separator - 1)];
            var stacks = Part1.ParseCrateStacks(crateStackLines);

            var rearrangementStepLines = lines[(separator + 1)..];
            var rearrangementSteps = Part1.ParseRearrangementSteps(rearrangementStepLines);

            foreach (var step in rearrangementSteps)
            {
                var movingStack = new Stack<Crate>();
                for (var i = 0; i < step.QuantityToMove; i++)
                {
                    var poppedCrate = stacks[step.SourceStack - 1].Pop();
                    movingStack.Push(poppedCrate);
                }

                while (movingStack.Count > 0)
                {
                    var poppedCrate = movingStack.Pop();
                    stacks[step.TargetStack - 1].Push(poppedCrate);
                }
            }

            foreach (var stack in stacks)
            {
                Console.Write(stack.Peek().Symbol);
            }
            Console.WriteLine();
        }
    }
}
