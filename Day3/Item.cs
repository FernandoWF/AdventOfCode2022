namespace Day3
{
    internal class Item
    {
        private const int LowercaseFirstPriority = 1;
        private const int UppercaseFirstPriority = 27;

        public char Letter { get; }
        public int Priority { get; }

        public Item(char letter)
        {
            if (!char.IsAsciiLetter(letter))
            {
                throw new ArgumentException($"'{letter}' is not a letter");
            }

            Letter = letter;

            Priority = char.IsBetween(letter, 'a', 'z')
                ? letter - 'a' + LowercaseFirstPriority
                : letter - 'A' + UppercaseFirstPriority;
        }
    }
}
