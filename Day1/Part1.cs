using Common;

namespace Day1
{
    internal class Part1 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var elves = new List<Elf>();

            var elf = new Elf();
            foreach (var line in lines)
            {
                if (line == string.Empty)
                {
                    elves.Add(elf);
                    elf = new Elf();
                    continue;
                }

                var calories = int.Parse(line);
                var food = new Food(calories);
                elf.CarriedFood.Add(food);
            }
            elves.Add(elf);

            Console.WriteLine(elves.Max(e => e.CaloriesCount));
        }
    }
}
