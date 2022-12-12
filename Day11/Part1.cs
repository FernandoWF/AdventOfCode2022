using Common;

namespace Day11
{
    internal class Part1 : ISolution
    {
        public const int MonkeyDescriptionLineCount = 6;
        public const int ItemsLineOffset = 1;
        public const int OperationParametersLineOffset = 2;
        public const int TestDivisorLineOffset = 3;
        public const int MonkeyToThrowIfTrueLineOffset = 4;
        public const int MonkeyToThrowIfFalseLineOffset = 5;

        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var monkeys = new List<Monkey>();

            for (var i = 0; i < lines.Length; i += MonkeyDescriptionLineCount + 1)
            {
                var items = ParseItems(lines[i + ItemsLineOffset]);
                var operationParameters = ParseOperationParameters(lines[i + OperationParametersLineOffset]);
                var testDivisor = ParseTestDivisor(lines[i + TestDivisorLineOffset]);
                var monkeyToThrowIfTrue = ParseMonkeyToThrowIfTrue(lines[i + MonkeyToThrowIfTrueLineOffset]);
                var monkeyToThrowIfFalse = ParseMonkeyToThrowIfFalse(lines[i + MonkeyToThrowIfFalseLineOffset]);

                var monkey = new Monkey(items, operationParameters, testDivisor, monkeyToThrowIfTrue, monkeyToThrowIfFalse);
                monkeys.Add(monkey);
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

        public static int[] ParseItems(string itemsLine)
        {
            var itemsValuesStartPosition = itemsLine.IndexOf("Starting items: ") + "Starting items: ".Length;
            return itemsLine[itemsValuesStartPosition..]
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
        }

        public static string ParseOperationParameters(string operationLine)
        {
            var operationParametersStartPosition = operationLine.IndexOf("Operation: new = old ") + "Operation: new = old ".Length;
            return operationLine[operationParametersStartPosition..];
        }

        public static int ParseTestDivisor(string testLine)
        {
            var testDivisorStartPosition = testLine.IndexOf("Test: divisible by ") + "Test: divisible by ".Length;
            return int.Parse(testLine[testDivisorStartPosition..]);
        }

        public static int ParseMonkeyToThrowIfTrue(string trueLine)
        {
            var monkeyToThrowIfTrueStartPosition = trueLine.LastIndexOf(' ') + 1;
            return int.Parse(trueLine[monkeyToThrowIfTrueStartPosition..]);
        }

        public static int ParseMonkeyToThrowIfFalse(string falseLine)
        {
            var monkeyToThrowIfFalseStartPosition = falseLine.LastIndexOf(' ') + 1;
            return int.Parse(falseLine[monkeyToThrowIfFalseStartPosition..]);
        }
    }
}
