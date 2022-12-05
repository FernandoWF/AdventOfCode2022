using Common;

namespace Day5
{
    internal class Part1 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var separator = GetIndexOfFirstEmptyLine(lines);

            var crateStackLines = lines[..(separator - 1)];
            var stacks = ParseCrateStacks(crateStackLines);

            var rearrangementStepLines = lines[(separator + 1)..];
            var rearrangementSteps = ParseRearrangementSteps(rearrangementStepLines);

            foreach (var step in rearrangementSteps)
            {
                for (var i = 0; i < step.QuantityToMove; i++)
                {
                    var poppedCrate = stacks[step.SourceStack - 1].Pop();
                    stacks[step.TargetStack - 1].Push(poppedCrate);
                }
            }

            foreach (var stack in stacks)
            {
                Console.Write(stack.Peek().Symbol);
            }
            Console.WriteLine();
        }

        public static int GetIndexOfFirstEmptyLine(IList<string> lines)
        {
            var index = 0;
            while (index < lines.Count)
            {
                if (lines[index] == string.Empty)
                {
                    return index;
                }

                index++;
            }

            return -1;
        }

        public static IList<Stack<Crate>> ParseCrateStacks(IList<string> lines)
        {
            lines = lines
                .Select(l => $"{l} ")
                .ToList();
            var crateLenght = 4;
            var stackCount = lines[0].Length / crateLenght;
            var stacks = new List<Stack<Crate>>();

            for (var i = 0; i < stackCount; i++)
            {
                stacks.Add(new Stack<Crate>());
            }

            for (var i = lines.Count - 1; i >= 0; i--)
            {
                var line = lines[i];
                for (var j = 0; j < line.Length; j += crateLenght)
                {
                    var currentStack = j / crateLenght;
                    var crateSymbolIndex = currentStack * crateLenght + 1;
                    var crateSymbol = line[crateSymbolIndex];

                    if (char.IsWhiteSpace(crateSymbol)) { continue; }

                    var crate = new Crate(crateSymbol);
                    stacks[currentStack].Push(crate);
                }
            }

            return stacks;
        }

        public static IList<RearrangementStep> ParseRearrangementSteps(IList<string> lines)
        {
            // move XX from XX to XX

            var steps = new List<RearrangementStep>();
            var quantityStartPosition = "move ".Length;

            foreach (var line in lines)
            {
                var quantityEndPosition = line.IndexOf(" from") - 1;
                var quantity = line[quantityStartPosition..(quantityEndPosition + 1)];

                var sourceStackStartPosition = quantityEndPosition + " from ".Length + 1;
                var sourceStackEndPosition = line.IndexOf(" to") - 1;
                var sourceStack = line[sourceStackStartPosition..(sourceStackEndPosition + 1)];

                var targetStackStartPosition = sourceStackEndPosition + " to ".Length + 1;
                var targetStackEndPosition = line.Length - 1;
                var targetStack = line[targetStackStartPosition..(targetStackEndPosition + 1)];

                steps.Add(new RearrangementStep(int.Parse(quantity), int.Parse(sourceStack), int.Parse(targetStack)));
            }

            return steps;
        }
    }
}
