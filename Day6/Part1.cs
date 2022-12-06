using Common;

namespace Day6
{
    internal class Part1 : ISolution
    {
        public static void Run()
        {
            var datastreamBuffer = File.ReadAllText("Input.txt");
            var startOfPacketMarkerLenght = 4;
            var positionOfMarkerEnd = GetPositionOfMarkerEnd(datastreamBuffer, startOfPacketMarkerLenght);

            Console.WriteLine(positionOfMarkerEnd);
        }

        public static int GetPositionOfMarkerEnd(string datastreamBuffer, int markerLength)
        {
            for (var i = markerLength - 1; i < datastreamBuffer.Length; i++)
            {
                var set = new HashSet<char>();
                for (var j = markerLength - 1; j >= 0; j--)
                {
                    set.Add(datastreamBuffer[i - j]);
                }

                if (set.Count == markerLength)
                {
                    return i + 1;
                }
            }

            return -1;
        }
    }
}
