using Common;

namespace Day11
{
    internal class Part2 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var monkeys = new List<Monkey>();

            var testDivisors = new List<int>();
            for (var i = Part1.TestDivisorLineOffset; i < lines.Length; i += Part1.MonkeyDescriptionLineCount + 1)
            {
                testDivisors.Add(Part1.ParseTestDivisor(lines[i]));
            }

            var testDivisorsFactor = 1;
            foreach (var item in testDivisors)
            {
                testDivisorsFactor *= item;
            }

            for (var i = 0; i < lines.Length; i += Part1.MonkeyDescriptionLineCount + 1)
            {
                var items = Part1.ParseItems(lines[i + Part1.ItemsLineOffset]);
                var operationParameters = Part1.ParseOperationParameters(lines[i + Part1.OperationParametersLineOffset]);
                var testDivisor = testDivisors[monkeys.Count];
                var monkeyToThrowIfTrue = Part1.ParseMonkeyToThrowIfTrue(lines[i + Part1.MonkeyToThrowIfTrueLineOffset]);
                var monkeyToThrowIfFalse = Part1.ParseMonkeyToThrowIfFalse(lines[i + Part1.MonkeyToThrowIfFalseLineOffset]);

                var monkey = new NonRelieverMonkey(items, operationParameters, testDivisor, monkeyToThrowIfTrue, monkeyToThrowIfFalse, testDivisorsFactor);
                monkeys.Add(monkey);
            }

            var roundCount = 10000;
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

            var monkeyBusiness = (long)monkeysOrderedByItemsInspected[0].ItemsInspected * monkeysOrderedByItemsInspected[1].ItemsInspected;

            Console.WriteLine(monkeyBusiness);
        }
    }
}
