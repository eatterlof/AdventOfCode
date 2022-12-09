using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace AoC2022.Solutions
{
    public class day7
    {
        private static readonly string[] input = File.ReadAllLines(@"../../../Inputs/7.txt");
        private static List<List<string>> allDirectories= new List<List<string>>();
        private static List<string> currentDirectory = new List<string>();
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
                        currentDirectory.Add(row);
                        continue;
                    }

                    if (int.TryParse(commands[0], out int n))
                    {
                        currentDirectory.Add(commands[0]);
                        continue;
                    }

                    if (commands[0] == "$")
                    {
                        listCurrentDirectory = false;
                        UserCommand(commands[1]);
                    }
                }

                if (commands[0] == "$")
                {
                    if (commands[1] == "cd")
                    {
                        ChangeDirectory(commands[2]);
                    }

                }
                if (commands[0] == "ls")
                {
                    listCurrentDirectory = true;
                }

                if (commands[0] == "dir")
                {

                }
            }
        }

        public static void SolveSecond()
        {
        }

        private static void ChangeDirectory(string direction)
        {
            if (direction == "..")
            {

            }
        }

        private static void UserCommand(string command)
        {

        }
    }
}
