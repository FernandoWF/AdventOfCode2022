using Common;

namespace Day7
{
    internal class Part1 : ISolution
    {
        public static void Run()
        {
            var lines = System.IO.File.ReadAllLines("Input.txt");
            var rootDirectory = ParseLines(lines);
            var sizeThreshold = 100000;
            var subdirectories = GetAllSubdirectoriesWithSizeWithinThreshold(rootDirectory, sizeThreshold).Except(new[] { rootDirectory });

            Console.WriteLine(subdirectories.Sum(d => d.Size));
        }

        public static Directory ParseLines(string[] lines)
        {
            var rootDirectory = new Directory();
            var currentDirectory = rootDirectory;
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) { continue; }

                if (line[.."$ ".Length] == "$ ")
                {
                    var command = ParseCommand(line);
                    if (command.Name == "cd")
                    {
                        if (command.Argument == "/")
                        {
                            currentDirectory = rootDirectory;
                        }
                        else if (command.Argument == "..")
                        {
                            currentDirectory = currentDirectory.ParentDirectory;
                        }
                        else
                        {
                            currentDirectory = currentDirectory.Directories.Single(d => d.Name == command.Argument);
                        }
                    }
                }
                else if (line[.."dir".Length] == "dir")
                {
                    var directoryName = line[("dir".Length + 1)..];
                    currentDirectory.Add(new Directory(directoryName, currentDirectory));
                }
                else
                {
                    var firstSpaceIndex = line.IndexOf(' ');
                    var rawSize = line[..firstSpaceIndex];

                    if (int.TryParse(rawSize, out var size))
                    {
                        var name = line[(firstSpaceIndex + 1)..];
                        currentDirectory.Add(new File(name, size));
                    }
                }
            }

            return rootDirectory;
        }

        public static Command ParseCommand(string line)
        {
            var secondSpaceIndex = line.IndexOf(' ', "$ ".Length);
            int nameEndIndex;
            string? argument;

            if (secondSpaceIndex == -1)
            {
                argument = null;
                nameEndIndex = line.Length - 1;
            }
            else
            {
                argument = line[(secondSpaceIndex + 1)..];
                nameEndIndex = secondSpaceIndex - 1;
            }
            var name = line["$ ".Length..(nameEndIndex + 1)];

            return new Command(name, argument);
        }

        private static IEnumerable<Directory> GetAllSubdirectoriesWithSizeWithinThreshold(Directory initialDirectory, int threshold)
        {
            if (initialDirectory.Size <= threshold) { yield return initialDirectory; }

            foreach (var directory in initialDirectory.Directories)
            {
                foreach (var subdirectory in GetAllSubdirectoriesWithSizeWithinThreshold(directory, threshold))
                {
                    yield return subdirectory;
                }
            }
        }
    }
}
