namespace Day11
{
    internal class Monkey
    {
        private const float WorryLevelDecreaseFactor = 3f;

        private readonly Queue<int> items = new();
        private readonly Func<int, int> worryLevelIncreaseOperation;
        private readonly int testDivisor;
        private readonly int monkeyToThrowIfTrue;
        private readonly int monkeyToThrowIfFalse;

        public int ItemsInspected { get; private set; } = 0;

        public Monkey(IReadOnlyList<int> items, string operation, int testDivisor, int monkeyToThrowIfTrue, int monkeyToThrowIfFalse)
        {
            foreach (var item in items)
            {
                this.items.Enqueue(item);
            }

            var operationParameters = operation.Split(' ');
            var @operator = operationParameters[0];
            var value = operationParameters[1];
            if (@operator == "+")
            {
                worryLevelIncreaseOperation = value == "old"
                    ? (w => w + w)
                    : (w => w + int.Parse(value));
            }
            else if (@operator == "*")
            {
                worryLevelIncreaseOperation = value == "old"
                    ? (w => w * w)
                    : (w => w * int.Parse(value));
            }
            else
            {
                throw new ArgumentException($"Invalid operator inside operation: {@operator}", nameof(operation));
            }

            this.testDivisor = testDivisor;
            this.monkeyToThrowIfTrue = monkeyToThrowIfTrue;
            this.monkeyToThrowIfFalse = monkeyToThrowIfFalse;
        }

        public void ExecuteTurn(IReadOnlyList<Monkey> monkeys)
        {
            while (items.Any())
            {
                var item = items.Dequeue();
                var newWorryLevel = worryLevelIncreaseOperation(item);
                newWorryLevel = (int)(newWorryLevel / WorryLevelDecreaseFactor);
                ItemsInspected++;

                var monkeyToThrow = newWorryLevel % testDivisor == 0
                    ? monkeyToThrowIfTrue
                    : monkeyToThrowIfFalse;

                monkeys[monkeyToThrow].EnqueueItem(newWorryLevel);
            }
        }

        public void EnqueueItem(int worryLevel)
        {
            items.Enqueue(worryLevel);
        }
    }
}
