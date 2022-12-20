using Common;

namespace Day13
{
    internal class Part1 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var rightOrderPairIndicesSum = 0;

            for (var i = 0; i < lines.Length; i += 3)
            {
                var leftPacket = new Packet(lines[i]);
                var rightPacket = new Packet(lines[i + 1]);

                var pairIndex = i / 3 + 1;

                if (ArePacketsInRightOrder(leftPacket, rightPacket))
                {
                    rightOrderPairIndicesSum += pairIndex;
                }
            }

            Console.WriteLine(rightOrderPairIndicesSum);
        }

        public static bool ArePacketsInRightOrder(Packet leftPacket, Packet rightPacket)
        {
            return AreInRightOrder(leftPacket, rightPacket)
                ?? throw new ArgumentException("Cannot decide if specified packets are in right order");
        }

        private static bool? AreInRightOrder(Integer left, Integer right)
        {
            if (left.Value < right.Value) { return true; }
            else if (left.Value > right.Value) { return false; }

            return null;
        }

        private static bool? AreInRightOrder(List left, List right)
        {
            for (var i = 0; i <= left.Count; i++)
            {
                if (i == left.Count || i == right.Count)
                {
                    if (i == left.Count && i == right.Count) { return null; }

                    return i == left.Count;
                }

                var leftValue = left[i];
                var rightValue = right[i];

                if (leftValue is Integer && rightValue is Integer)
                {
                    var leftInteger = (Integer)leftValue;
                    var rightInteger = (Integer)rightValue;

                    var result = AreInRightOrder(leftInteger, rightInteger);
                    if (result != null) { return result.Value; }
                }
                else if (leftValue is Integer && rightValue is List)
                {
                    var leftList = new List($"[{(Integer)leftValue}]", 0);
                    var rightList = (List)rightValue;

                    var result = AreInRightOrder(leftList, rightList);
                    if (result != null) { return result.Value; }
                }
                else if (leftValue is List && rightValue is Integer)
                {
                    var leftList = (List)leftValue;
                    var rightList = new List($"[{(Integer)rightValue}]", 0);

                    var result = AreInRightOrder(leftList, rightList);
                    if (result != null) { return result.Value; }
                }
                else
                {
                    var leftList = (List)leftValue;
                    var rightList = (List)rightValue;

                    var result = AreInRightOrder(leftList, rightList);
                    if (result != null) { return result.Value; }
                }
            }

            return null;
        }
    }
}
