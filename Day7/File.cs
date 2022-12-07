namespace Day7
{
    internal class File
    {
        public string Name { get; }
        public int Size { get; }

        public File(string name, int size)
        {
            Name = name;
            Size = size;
        }
    }
}
