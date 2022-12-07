namespace Day7
{
    internal class Directory
    {
        public string Name { get; }
        public List<Directory> Directories { get; } = new List<Directory>();
        public List<File> Files { get; } = new List<File>();
        public Directory ParentDirectory { get; }
        public int Size => Directories.Sum(d => d.Size) + Files.Sum(f => f.Size);

        public Directory()
        {
            Name = string.Empty;
            ParentDirectory = this;
        }

        public Directory(string name, Directory parentDirectory)
        {
            Name = name;
            ParentDirectory = parentDirectory;
        }

        public void Add(Directory directory)
        {
            Directories.Add(directory);
        }

        public void Add(File file)
        {
            Files.Add(file);
        }
    }
}
