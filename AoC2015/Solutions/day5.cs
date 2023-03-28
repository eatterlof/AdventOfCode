using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2015.Solutions
{
    public class day5
    {
        private static readonly string[] input = File.ReadLines(@"../../../Inputs/5.txt").ToArray();
        private static readonly List<string> vowels = new List<string>() { "a", "e", "i", "o", "u" };
        private static readonly List<string> disallowedStrings = new List<string>() { "ab", "cd", "pq", "xy" };

        public static void SolveFirst()
        {
            int amountOfNiceStrings = 0;
            foreach (var stringg in input)
            {
                if (isStringNice(stringg))
                    amountOfNiceStrings++;
            }
            Console.WriteLine(amountOfNiceStrings);
        }

        private static bool isStringNice(string input)
        {
            int amountOfVowels = 0;
            bool doubleCharacter = false;

            var previousCharacter = "Can'tBeThisOne:)";
            foreach (var c in input)
            {
                var comparer = c.ToString();
                if (vowels.Contains(comparer))
                    amountOfVowels++;

                if (previousCharacter == comparer)
                    doubleCharacter = true;

                var doubleChar = previousCharacter + comparer;
                if (disallowedStrings.Contains(doubleChar))
                {
                    return false;
                }
                previousCharacter = comparer;
            }

            if (amountOfVowels >= 3 && doubleCharacter == true)
                return true;

            return false;
        }

        public static void SolveSecond()
        {
            var amountOfNiceStrings = 0;
            foreach (var stringg in input)
            {
                if (IsStringNice2(stringg))
                    amountOfNiceStrings++;
            }
            Console.WriteLine(amountOfNiceStrings);
        }

        private static bool IsStringNice2(string input)
        {
            bool containsTwoNonOverlappingPairs = false;
            bool containsRepeatedLetterWithOneLetterBetween = false;

            for (int i = 0; i < input.Length - 1; i++)
            {
                string pair = input.Substring(i, 2);
                int index = input.IndexOf(pair, i + 2);
                if (index != -1)
                {
                    containsTwoNonOverlappingPairs = true;
                    break;
                }
            }

            for (int i = 0; i < input.Length - 2; i++)
            {
                if (input[i] == input[i + 2])
                {
                    containsRepeatedLetterWithOneLetterBetween = true;
                    break;
                }
            }

            return containsTwoNonOverlappingPairs && containsRepeatedLetterWithOneLetterBetween;
        }

    }
}
