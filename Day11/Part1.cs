using Common;

namespace Day11
{
    internal class Part1 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var monkeyDescriptionLineCount = 6;
            var monkeys = new List<Monkey>();

            for (var i = 0; i < lines.Length; i += monkeyDescriptionLineCount + 1)
            {
                var itemsLine = lines[i + 1];
                var operationLine = lines[i + 2];
                var testLine = lines[i + 3];
                var trueLine = lines[i + 4];
                var falseLine = lines[i + 5];

                monkeys.Add(ParseMonkey(itemsLine, operationLine, testLine, trueLine, falseLine));
            }

            var roundCount = 20;

            for (var i = 0; i < roundCount; i++)
            {
                foreach (var monkey in monkeys)
                {
                    monkey.ExecuteTurn(monkeys);
                }
            }

            var monkeysOrderedByItemsInspected = monkeys
                .OrderByDescending(m => m.ItemsInspected)
                .ToList();

            var monkeyBusiness = monkeysOrderedByItemsInspected[0].ItemsInspected * monkeysOrderedByItemsInspected[1].ItemsInspected;

            Console.WriteLine(monkeyBusiness);
        }

        public static Monkey ParseMonkey(
            string itemsLine,
            string operationLine,
            string testLine,
            string trueLine,
            string falseLine)
        {
            var itemsValuesStartPosition = itemsLine.IndexOf("Starting items: ") + "Starting items: ".Length;
            var items = itemsLine[itemsValuesStartPosition..]
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            var operationParametersStartPosition = operationLine.IndexOf("Operation: new = old ") + "Operation: new = old ".Length;
            var operationParameters = operationLine[operationParametersStartPosition..];

            var testDivisorStartPosition = testLine.IndexOf("Test: divisible by ") + "Test: divisible by ".Length;
            var testDivisor = int.Parse(testLine[testDivisorStartPosition..]);

            var monkeyToThrowIfTrueStartPosition = trueLine.LastIndexOf(' ') + 1;
            var monkeyToThrowIfTrue = int.Parse(trueLine[monkeyToThrowIfTrueStartPosition..]);

            var monkeyToThrowIfFalseStartPosition = falseLine.LastIndexOf(' ') + 1;
            var monkeyToThrowIfFalse = int.Parse(falseLine[monkeyToThrowIfTrueStartPosition..]);

            return new Monkey(items, operationParameters, testDivisor, monkeyToThrowIfTrue, monkeyToThrowIfFalse);
        }
    }
}
