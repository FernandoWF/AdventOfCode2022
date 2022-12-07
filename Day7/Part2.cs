using Common;

namespace Day7
{
    internal class Part2 : ISolution
    {
        public static void Run()
        {
            var lines = System.IO.File.ReadAllLines("Input.txt");
            var rootDirectory = Part1.ParseLines(lines);
            var totalDiskSpace = 70000000;
            var targetFreeSpace = 30000000;
            var currentFreeSpace = totalDiskSpace - rootDirectory.Size;
            var freeSpaceStillNeeded = targetFreeSpace - currentFreeSpace;
            var subdirectories = GetAllSubdirectoriesWithSizeAboveThreshold(rootDirectory, freeSpaceStillNeeded);
            var subdirectoryToDelete = subdirectories
                .Where(d => d.Size >= freeSpaceStillNeeded)
                .MinBy(d => d.Size)!;

            Console.WriteLine(subdirectoryToDelete.Size);
        }

        public static IEnumerable<Directory> GetAllSubdirectoriesWithSizeAboveThreshold(Directory initialDirectory, int threshold)
        {
            if (initialDirectory.Size >= threshold) { yield return initialDirectory; }

            foreach (var directory in initialDirectory.Directories)
            {
                foreach (var subdirectory in GetAllSubdirectoriesWithSizeAboveThreshold(directory, threshold))
                {
                    yield return subdirectory;
                }
            }
        }
    }
}
