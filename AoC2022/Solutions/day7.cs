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
            Console.WriteLine(CalculateSum(outermostDirectory));
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

        private static string CalculateSum(Directory outermostDirectory)
        {
            int sum = 0;

            foreach (var file in outermostDirectory.files)
            {
                int filesize = file.Item1;
                if (filesize <= 100000)
                    sum += file.Item1;
            }



            return sum.ToString();
        }
    }



    class Directory
    {
        public string? directoryName;
        public List<(int, string)> files;
        public List<Directory>? directories;
        public Directory? parentDirectory;

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
