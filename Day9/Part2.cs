using Common;

namespace Day9
{
    internal class Part2 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var rope = new Rope(10);

            foreach (var line in lines)
            {
                var direction = Part1.ParseDirection(line[0]);
                var steps = int.Parse(line[2..]);
                rope.MoveHead(direction, steps);
            }

            Console.WriteLine(rope.PositionsTailVisited.Count);
        }
    }
}
