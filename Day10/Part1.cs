using Common;

namespace Day10
{
    internal class Part1 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var cpu = new CPU();

            foreach (var line in lines)
            {
                var commandKind = line[..4];

                if (commandKind == "noop")
                {
                    cpu.QueueNoop();
                }
                else if (commandKind == "addx")
                {
                    var argument = int.Parse(line[5..]);
                    cpu.QueueAddX(argument);
                }
            }

            var cyclesToSumSignalStrength = new[] { 20, 60, 100, 140, 180, 220 };
            var signalStrengthSum = 0;

            while (cpu.HasCommands)
            {
                cpu.ExecuteCycle();

                if (cyclesToSumSignalStrength.Contains(cpu.LastCycleExecuted))
                {
                    var signalStrength = cpu.LastCycleExecuted * cpu.RegisterValueDuringLastCycle;
                    signalStrengthSum += signalStrength;
                }
            }

            Console.WriteLine(signalStrengthSum);
        }
    }
}
