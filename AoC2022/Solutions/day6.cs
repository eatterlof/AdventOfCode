using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace AoC2022.Solutions
{
    public class day6
    {
        private static readonly string input = File.ReadAllText(@"../../../Inputs/6.txt");
        private static string first = null;
        private static string second = null;
        private static string third = null;
        private static string fourth = null;
        private static List<string> characters = new List<string>();

        public static void SolveFirst()
        {
            for (int counter = 1; counter < input.Length; counter++)
            {
                if (first == null)
                {
                    first = input[counter].ToString();
                    continue;
                }

                if (second == null)
                {
                    second = input[counter].ToString();
                    continue;
                }

                if (third == null)
                {
                    third = input[counter].ToString();
                    continue;
                }

                if (fourth == null)
                {
                    fourth = input[counter].ToString();
                    continue;
                }

                var list = new List<string>() { first, second, third, fourth };

                if (list.Count == list.Distinct().Count())
                {
                    break;
                }

                UpdateNumbers(input[counter].ToString());
            }
        }

        public static void SolveSecond()
        {
            for (int counter = 0; counter < input.Length; counter++)
            {
                characters.Add(input[counter].ToString());

                if (characters.Count >= 14)
                {
                    var done = CheckIfRepeated(characters);
                    if (done)
                    {
                        Console.WriteLine(counter + 1);
                        return;
                    }
                }
            }
        }

        private static void UpdateNumbers(string newLetter)
        {
            first = second;
            second = third;
            third = fourth;
            fourth = newLetter;
        }

        private static bool CheckIfRepeated(List<string> characters)
        {
            var last14 = characters.Skip(Math.Max(0, characters.Count() - 14)).ToList();

            if (last14.Count == last14.Distinct().Count())
                return true;

            return false;
        }
    }
}
