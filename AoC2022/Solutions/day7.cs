using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace AoC2022.Solutions
{
    public class day7
    {
        private static readonly string[] input = File.ReadAllLines(@"../../../Inputs/7.txt");

        private static Directory currentDirectory = new Directory();
        private static bool listCurrentDirectory = false;
        private static int fileSum = 0;

        public static void SolveFirst()
        {
            foreach (var row in input)
            {
                var commands = row.Split(" ");

                if (listCurrentDirectory)
                {
                    if (commands[0] == "dir")
                    {
                        currentDirectory.AddDirectory(currentDirectory, commands[1]);
                        continue;
                    }

                    if (int.TryParse(commands[0], out int n))
                    {
                        currentDirectory.AddFile(currentDirectory, commands[1], n);
                        continue;
                    }

                    if (commands[0] == "$")
                    {
                        listCurrentDirectory = false;
                        UserCommand(commands);
                        continue;
                    }
                }

                if (commands[1] == "cd")
                {
                    currentDirectory = ChangeDirectory(commands[2]);
                }
                if (commands[1] == "ls")
                {
                    listCurrentDirectory = true;
                }
            }
            var outermostDirectory = GetOutermostDirectory(currentDirectory);
            CalculateSum(outermostDirectory);
            Console.WriteLine(fileSum);
        }

        public static void SolveSecond()
        {
        }
        private static void UserCommand(string[] commands)
        {
            if (commands[1] == "cd")
            {
                currentDirectory = ChangeDirectory(commands[2]);
            }
            if (commands[1] == "ls")
            {
                listCurrentDirectory = true;
            }
        }

        private static Directory ChangeDirectory(string direction)
        {
            if (direction == "..")
                return currentDirectory.GoToPreviousDirectory(currentDirectory);

            if (direction == "/")
                return GetOutermostDirectory(currentDirectory);

            else
                return currentDirectory.StepIntoDirectory(currentDirectory, direction);
        }

        private static Directory GetOutermostDirectory(Directory currentDirectory)
        {
            Directory parentDirectory = null;

            if (currentDirectory.parentDirectory != null)
                parentDirectory = currentDirectory.GoToPreviousDirectory(currentDirectory);

            else if (currentDirectory.parentDirectory == null)
                return currentDirectory;

            if (parentDirectory != null && parentDirectory.parentDirectory == null)
                return parentDirectory;

            GetOutermostDirectory(parentDirectory);
            return null;
        }

        private static void CalculateSum(Directory directory)
        {
            CalculateFilesInDirectory(directory);
            int sumForDirectory = 0; // Skicka med denna i CalculateSum och lägg till alla i den här. Kolla sedan om den är under 100k och isf lägg till i tot?
            if (directory.directories != null && directory.directories.Count > 0)
                foreach (var dir in directory.directories)
                {
                    if (!dir.hasBeenCounted)
                        CalculateSum(dir);
                }

        }

        private static void CalculateFilesInDirectory(Directory directory)
        {
            var totFileSize = 0;
            foreach (var file in directory.files)
            {
                int filesize = file.Item1;
                if (filesize <= 100000)
                    totFileSize += file.Item1;
            }

            directory.directoryTotalFileSize = totFileSize;
            directory.hasBeenCounted = true;

            if (totFileSize < 100000)
                fileSum += totFileSize;
        }
    }



    class Directory
    {
        public string? directoryName;
        public List<(int, string)> files;
        public List<Directory>? directories;
        public Directory? parentDirectory;
        public bool hasBeenCounted = false;
        public int directoryTotalFileSize = 0;
        public int directoryAndChildrenTotalFileSize = 0;

        public Directory()
        {
            directoryName = null;
            files = new List<(int, string)>();
            directories = null;
            parentDirectory = null;
        }

        public Directory AddFile(Directory directory, string filename, int filesize)
        {
            directory.files.Add((filesize, filename));
            return directory;
        }

        public Directory AddDirectory(Directory directory, string name)
        {
            var newDirectory = new Directory() { directoryName = name, parentDirectory = directory };
            if (directory.directories == null)
                directory.directories = new List<Directory>();
            directory.directories.Add(newDirectory);
            return directory;
        }

        public Directory GoToPreviousDirectory(Directory currentDirectory)
        {
            return currentDirectory.parentDirectory;
        }

        public Directory StepIntoDirectory(Directory currentDirectory, string directoryNameToStepInto)
        {
            var directoryToStepInto = currentDirectory.directories.First(d => d.directoryName == directoryNameToStepInto);
            return directoryToStepInto;
        }


    }
}
