using Common;

namespace Day2
{
    internal class Part1 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var totalScore = 0;

            foreach (var line in lines)
            {
                var opponentShape = Shape.FromOpponentSymbol(line[0]);
                var yourShape = Shape.FromYourSymbol(line[2]);
                totalScore += new Round(opponentShape, yourShape).YourScore;
            }

            Console.WriteLine(totalScore);
        }
    }
}
