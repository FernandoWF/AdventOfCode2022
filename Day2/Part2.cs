using Common;

namespace Day2
{
    internal class Part2 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var totalScore = 0;

            foreach (var line in lines)
            {
                var opponentShape = Shape.FromOpponentSymbol(line[0]);
                var desiredOutcome = ParseDesiredOutcome(line[2]);
                totalScore += new Round(opponentShape, desiredOutcome).YourScore;
            }

            Console.WriteLine(totalScore);
        }

        private static Outcome ParseDesiredOutcome(char symbol)
        {
            return symbol switch
            {
                'X' => Outcome.YouLose,
                'Y' => Outcome.Draw,
                'Z' => Outcome.YouWin,
                _ => throw new ArgumentOutOfRangeException(nameof(symbol), $"'{symbol}' is not a valid desired outcome")
            };
        }
    }
}
