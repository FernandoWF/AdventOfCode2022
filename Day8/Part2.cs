using Common;

namespace Day8
{
    internal class Part2 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var map = Part1.ParseMap(lines);

            var highestScenicScore = 0;
            for (var y = 0; y < map.Height; y++)
            {
                for (var x = 0; x < map.Width; x++)
                {
                    var scenicScore = map.GetScenicScore(x, y);
                    if (scenicScore > highestScenicScore) { highestScenicScore = scenicScore; }
                }
            }

            Console.WriteLine(highestScenicScore);
        }
    }
}
