using Common;

namespace Day6
{
    internal class Part2 : ISolution
    {
        public static void Run()
        {
            var datastreamBuffer = File.ReadAllText("Input.txt");
            var startOfMessageMarkerLenght = 14;
            var positionOfMarkerEnd = Part1.GetPositionOfMarkerEnd(datastreamBuffer, startOfMessageMarkerLenght);

            Console.WriteLine(positionOfMarkerEnd);
        }
    }
}
