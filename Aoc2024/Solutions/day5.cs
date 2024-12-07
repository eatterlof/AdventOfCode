using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aoc2024.Solutions
{
    public class day5
    {
        public static void SolveFirst()
        {
            var inputRows = File.ReadAllLines(@"../../../Inputs/5.txt");

            int dividerIndex = Array.IndexOf(inputRows, "");

            string[] rules = inputRows[..dividerIndex];
            string[] updates = inputRows[(dividerIndex + 1)..];

            int updateNumbersTotal = 0;
            foreach (var update in updates) 
            {
                string[] stringParts = update.Split(',');
                int[] updateNumbers = Array.ConvertAll(stringParts, int.Parse);

                bool isCorrectOrder = IsUpdateCorrect(updateNumbers, rules);

                if (isCorrectOrder) 
                {
                    int middleIndex = updateNumbers.Length / 2;
                    int middleNumber = updateNumbers[middleIndex];
                    updateNumbersTotal += middleNumber;
                }
            }

            Console.WriteLine(updateNumbersTotal);
        }

        public static void SolveSecond()
        {
            var inputRows = File.ReadAllLines(@"../../../Inputs/5.txt");

            int dividerIndex = Array.IndexOf(inputRows, "");

            string[] rules = inputRows[..dividerIndex];
            string[] updates = inputRows[(dividerIndex + 1)..];

            int updateNumbersTotal = 0;
            foreach (var update in updates)
            {
                string[] stringParts = update.Split(',');
                int[] updateNumbers = Array.ConvertAll(stringParts, int.Parse);

                bool isCorrectOrder = IsUpdateCorrect(updateNumbers, rules);

                if (!isCorrectOrder)
                {
                    List<int> updateList = updateNumbers.ToList();

                    while (!isCorrectOrder)
                    {
                        foreach (var rule in rules)
                        {
                            string[] numbers = rule.Split('|');

                            int left = int.Parse(numbers[0]);
                            int right = int.Parse(numbers[1]);

                            if (!updateList.Contains(left) || !updateList.Contains(right))
                                continue;

                            int leftIndex = updateList.IndexOf(left);
                            int rightIndex = updateList.IndexOf(right);

                            if (leftIndex < rightIndex)
                                continue;

                            updateList.Remove(left);
                            int newRightIndex = updateList.IndexOf(right);
                            updateList.Insert(newRightIndex, left);
                        }


                        isCorrectOrder = IsUpdateCorrect(updateList.ToArray(), rules);
                    }

                    int middleIndex = updateList.Count / 2;
                    int middleNumber = updateList[middleIndex];
                    updateNumbersTotal += middleNumber;
                }
            }

            Console.WriteLine(updateNumbersTotal);
        }

        public static bool IsUpdateCorrect(int[] updateNumbers, string[] rules)
        {
            bool isCorrectOrder = true;
            
            foreach (var rule in rules)
            {
                string[] numbers = rule.Split('|');

                int firstNumber = int.Parse(numbers[0]);
                int secondNumber = int.Parse(numbers[1]);

                int indexFirst = Array.IndexOf(updateNumbers, firstNumber);
                int indexSecond = Array.IndexOf(updateNumbers, secondNumber);

                if (indexFirst == -1 || indexSecond == -1)
                    continue;

                if (indexFirst < indexSecond)
                    continue;

                isCorrectOrder = false;
            }

            return isCorrectOrder;
        }
    }
}
