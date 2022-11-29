namespace Common
{
    public static class DayRunner<TPart1, TPart2>
        where TPart1 : ISolution
        where TPart2 : ISolution
    {
        public static void Run()
        {
            Console.WriteLine("========== Part 1 ==========");
            TPart1.Run();

            Console.WriteLine();

            Console.WriteLine("========== Part 2 ==========");
            TPart2.Run();
        }
    }
}
