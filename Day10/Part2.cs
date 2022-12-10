using Common;

namespace Day10
{
    internal class Part2 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var cpu = Part1.ParseCPU(lines);
            var crtWidth = 40;
            var crtHeight = 6;
            var crt = new char[crtWidth, crtHeight];

            while (cpu.HasCommands)
            {
                cpu.ExecuteCycle();

                var line = (cpu.LastCycleExecuted - 1) / crtWidth;
                var column = (cpu.LastCycleExecuted - 1) % crtWidth;

                if (column == cpu.RegisterValueDuringLastCycle
                    || column - 1 == cpu.RegisterValueDuringLastCycle
                    || column + 1 == cpu.RegisterValueDuringLastCycle)
                {
                    crt[column, line] = '#';
                }
                else
                {
                    crt[column, line] = '.';
                }
            }

            for (var line = 0; line < crtHeight; line++)
            {
                for (var column = 0; column < crtWidth; column++)
                {
                    Console.Write(crt[column, line]);
                }
                Console.WriteLine();
            }
        }
    }
}
