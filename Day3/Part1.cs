using Common;

namespace Day3
{
    internal class Part1 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var rucksacks = lines
                .Select(l => new Rucksack(l))
                .ToList();

            Console.WriteLine(rucksacks.Sum(r => r.CommonItem.Priority));
        }
    }
}
