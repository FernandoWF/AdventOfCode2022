namespace Day1
{
    internal class Elf
    {
        public List<Food> CarriedFood { get; } = new List<Food>();
        public int CalorieCount => CarriedFood.Sum(f => f.Calories);
    }
}
