using Common;

namespace Day6
{
    internal class Part1 : ISolution
    {
        public static void Run()
        {
            var datastreamBuffer = File.ReadAllText("Input.txt");
            var startOfMessageMarkerLenght = 4;

            for (var i = startOfMessageMarkerLenght - 1; i < datastreamBuffer.Length; i++)
            {
                var set = new HashSet<char>();
                for (var j = startOfMessageMarkerLenght - 1; j >= 0; j--)
                {
                    set.Add(datastreamBuffer[i - j]);
                }

                if (set.Count == startOfMessageMarkerLenght)
                {
                    Console.WriteLine(i + 1);
                    return;
                }
            }
        }
    }
}
