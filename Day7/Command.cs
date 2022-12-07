namespace Day7
{
    internal class Command
    {
        public string Name { get; }
        public string? Argument { get; }

        public Command(string name, string? argument)
        {
            Name = name;
            Argument = argument;
        }
    }
}
