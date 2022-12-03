using Common;

namespace Day3
{
    internal class Part2 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var rucksacks = lines
                .Select(l => new Rucksack(l))
                .ToList();

            var elvesPerGroup = 3;
            var badges = rucksacks
                .Chunk(elvesPerGroup)
                .Select(r =>
                {
                    var badgeLetter = r[0].ItemTypes
                        .Intersect(r[1].ItemTypes)
                        .Intersect(r[2].ItemTypes)
                        .Single();

                    return new Item(badgeLetter);
                })
                .ToList();

            Console.WriteLine(badges.Sum(b => b.Priority));
        }
    }
}
