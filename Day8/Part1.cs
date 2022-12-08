using Common;

namespace Day8
{
    internal class Part1 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var map = ParseMap(lines);

            var visibleTrees = 0;
            for (var y = 0; y < map.Height; y++)
            {
                for (var x = 0; x < map.Width; x++)
                {
                    if (map.IsTreeVisible(x, y)) { visibleTrees++; }
                }
            }

            Console.WriteLine(visibleTrees);
        }

        private static Map ParseMap(string[] lines)
        {
            var width = lines.First().Length;
            var height = lines.Length;
            var map = new Map(width, height);

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    map[x, y] = int.Parse(lines[y][x].ToString());
                }
            }

            return map;
        }
    }
}
