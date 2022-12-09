using Common;

namespace Day9
{
    internal class Part1 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var rope = new Rope();

            foreach (var line in lines)
            {
                var direction = ParseDirection(line[0]);
                var steps = int.Parse(line[2..]);
                rope.MoveHead(direction, steps);
            }

            Console.WriteLine(rope.PositionsTailVisited.Count);
        }

        public static Direction ParseDirection(char direction)
        {
            return direction switch
            {
                'U' => Direction.Up,
                'D' => Direction.Down,
                'L' => Direction.Left,
                'R' => Direction.Right,
                _ => throw new ArgumentOutOfRangeException(nameof(direction)),
            };
        }
    }
}
