using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC22.Solutions
{
    public class day1
    {
        public static void SolveFirst()
        {
            var inputRows = File.ReadAllLines("C:\\mvs\\adventOfCode2022\\AoC22\\Inputs\\1.txt");

            int highestFood = 0;
            int currentElfFood = 0;

            foreach (var row in inputRows)
            {
                if (!String.IsNullOrEmpty(row))
                {
                    currentElfFood += Int32.Parse(row);
                }

                if (String.IsNullOrEmpty(row))
                {
                    if (currentElfFood > highestFood)
                        highestFood = currentElfFood;

                    currentElfFood = 0;
                }
            }

            Console.WriteLine(highestFood);
        }

        public static void SolveSecond()
        {
            var inputRows = File.ReadAllLines("C:\\mvs\\adventOfCode2022\\AoC22\\Inputs\\1.txt");

            int highestFood = 0;
            int secondHighestFood = 0;
            int thirdHighestFood = 0;
            int currentElfFood = 0;

            foreach (var row in inputRows)
            {
                if (!String.IsNullOrEmpty(row))
                {
                    currentElfFood += Int32.Parse(row);
                }

                if (String.IsNullOrEmpty(row))
                {
                    if (currentElfFood > thirdHighestFood && currentElfFood > secondHighestFood && currentElfFood > highestFood)
                    {
                        thirdHighestFood = secondHighestFood;
                        secondHighestFood = highestFood;
                        highestFood = currentElfFood;
                    }

                    if (currentElfFood > thirdHighestFood && currentElfFood > secondHighestFood && currentElfFood < highestFood)
                    {
                        thirdHighestFood = secondHighestFood;
                        secondHighestFood = currentElfFood;
                    }

                    if (currentElfFood > thirdHighestFood && currentElfFood < secondHighestFood)
                        thirdHighestFood = currentElfFood;

                    currentElfFood = 0;
                }
            }

            Console.WriteLine("Highest: " + highestFood);
            Console.WriteLine("Second: " + secondHighestFood);
            Console.WriteLine("Third: " + thirdHighestFood);

            int total = highestFood + secondHighestFood + thirdHighestFood;

            Console.WriteLine("Total: " + total);
        }
    }
}
