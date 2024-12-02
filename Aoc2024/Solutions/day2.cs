using System.Runtime.CompilerServices;

namespace Aoc2024.Solutions
{
    public class day2
    {
        public static void SolveFirst()
        {
            var inputRows = File.ReadAllLines(@"../../../Inputs/2.txt");

            var safes = 0;
            var unsafes = 0;

            foreach (var row in inputRows) 
            {
                string[] parts = row.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                var isSafe = true;
                var previousLevel = 0;
                var isIncreasing = true;
                bool isFirst = true;
                bool isSecond = true;

                foreach (var part in parts)
                {
                    var level = int.Parse(part);

                    if (isFirst)
                    {
                        isFirst = false;
                        previousLevel = level;
                        continue;
                    }

                    if (isSecond)
                    {
                        isSecond = false;

                        if (level < previousLevel)
                            isIncreasing = false;
                    }

                    if (isIncreasing && level < previousLevel)
                        isSafe = false;

                    if (!isIncreasing && level > previousLevel)
                        isSafe = false;


                    var topRange = previousLevel + 3;
                    var bottomRange = previousLevel - 3;

                    if (level > topRange || level < bottomRange || level == previousLevel)
                        isSafe = false;

                    previousLevel = level;

                    
                }
                Console.WriteLine(isSafe);
                if (isSafe) safes++;
                else unsafes++;
            }

            Console.WriteLine(safes.ToString());
            Console.WriteLine(unsafes.ToString());
        }

        private static bool IsRowSafe(string[] parts)
        {
            var isSafe = true;
            var previousLevel = 0;
            var isIncreasing = true;
            bool isFirst = true;
            bool isSecond = true;

            foreach (var part in parts)
            {
                var level = int.Parse(part);

                if (isFirst)
                {
                    isFirst = false;
                    previousLevel = level;
                    continue;
                }

                if (isSecond)
                {
                    isSecond = false;

                    if (level < previousLevel)
                        isIncreasing = false;
                }

                if (isIncreasing && level < previousLevel)
                    isSafe = false;

                if (!isIncreasing && level > previousLevel)
                    isSafe = false;


                var topRange = previousLevel + 3;
                var bottomRange = previousLevel - 3;

                if (level > topRange || level < bottomRange || level == previousLevel)
                    isSafe = false;

                previousLevel = level;
            }

            return isSafe;
        }

        public static void SolveSecond()
        {
            var inputRows = File.ReadAllLines(@"../../../Inputs/2.txt");

            var safes = 0;
            var unsafes = 0;

            foreach (var row in inputRows) 
            {
                string[] parts = row.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                var isSafe = IsRowSafe(parts);

                if (!isSafe)
                {
                    for (var i = 0; i < parts.Length; i++)
                    {
                        // Create a new array excluding the element at index i
                        string[] newArray = parts
                            .Where((value, index) => index != i) // Keep all elements except the one at index i
                            .ToArray();

                        // Call the IsRowSafe method with the new array
                        isSafe = IsRowSafe(newArray);

                        if (isSafe)
                            break;
                    }
                }

                if (isSafe) safes++;
                else unsafes++;
            }

            Console.WriteLine(safes);
            Console.WriteLine(unsafes);
        }
    }
}
