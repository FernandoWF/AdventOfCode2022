namespace Day5
{
    internal class Crate
    {
        public char Symbol { get; }

        public Crate(char symbol)
        {
            Symbol = symbol;
        }

        public override string ToString()
        {
            return Symbol.ToString();
        }
    }
}
