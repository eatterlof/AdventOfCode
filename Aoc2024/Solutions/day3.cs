using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Aoc2024.Solutions
{
    public class day3
    {
        public static void SolveFirst()
        {
            var inputRows = File.ReadAllLines(@"../../../Inputs/3.txt");

            int total = 0;

            // Regex pattern for "mul(x,y)" where x and y are 1-3 digit numbers
            string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";

            List<Match> allMatches = new List<Match>();

            foreach (var row in inputRows)
            {
                allMatches.AddRange(Regex.Matches(row, pattern));
            }

            foreach (Match match in allMatches)
            {
                var x = int.Parse(match.Groups[1].Value);    // First number (x)
                var y = int.Parse(match.Groups[2].Value);    // Second number (y)

                var mul = x * y;
                total += mul;
            }

            Console.WriteLine(total);
        }

        
        public static void SolveSecond()
        {
            var inputRows = File.ReadAllLines(@"../../../Inputs/3.txt");

            int total = 0;

            string matchPattern = @"mul\((\d{1,3}),(\d{1,3})\)";
            string controlPattern = @"don't\(\)|do\(\)";

            bool instructionsEnabled = true;

            List<Match> allMatches = new List<Match>();

            string allRows = "";

            foreach (var row in inputRows)
            {
                allRows += row;
            }

            foreach (Match controlMatch in Regex.Matches(allRows, $@"{matchPattern}|{controlPattern}"))
            {
                string value = controlMatch.Value;

                if (value == "don't()")
                    instructionsEnabled = false;

                if (value == "do()")
                    instructionsEnabled = true;

                else if (instructionsEnabled && value.StartsWith("mul("))
                {
                    allMatches.Add(controlMatch);
                }

            }

            foreach (Match match in allMatches) 
            {
                var x = int.Parse(match.Groups[1].Value);    // First number (x)
                var y = int.Parse(match.Groups[2].Value);    // Second number (y)

                var mul = x * y;
                total += mul;
            }

            Console.WriteLine(total);
        }
    }
}
