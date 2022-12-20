using Common;

namespace Day13
{
    internal class Part2 : ISolution
    {
        private const string FirstDividerPacketBody = "[[2]]";
        private const string SecondDividerPacketBody = "[[6]]";

        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var packets = lines
                .Where(l => !string.IsNullOrEmpty(l))
                .Append(FirstDividerPacketBody)
                .Append(SecondDividerPacketBody)
                .Select(b => new Packet(b))
                .ToList();

            packets.Sort((left, right) => Part1.ArePacketsInRightOrder(left, right) ? -1 : 1);

            var firstDividerPacketIndex = packets.IndexOf(packets.Single(p => p.Body == FirstDividerPacketBody)) + 1;
            var secondDividerPacketIndex = packets.IndexOf(packets.Single(p => p.Body == SecondDividerPacketBody)) + 1;

            var decoderKey = firstDividerPacketIndex * secondDividerPacketIndex;

            Console.WriteLine(decoderKey);
        }
    }
}
