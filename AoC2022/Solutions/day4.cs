using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022.Solutions
{
    public class day4
    {
        private static readonly string[] inputRows = File.ReadAllLines(@"../../../Inputs/4.txt");
        private static int numberOfPairsFullyContained = 0;

        public static void SolveFirst()
        {
            foreach (var row in inputRows)
            {
                var elves = row.Split(",");

                var elf1Assignments = elves[0].Split("-");
                var elf2Assignments = elves[1].Split("-");

                var contained = isFullyContained(elf1Assignments, elf2Assignments);

                if (contained)
                    numberOfPairsFullyContained++;
            }

            Console.WriteLine(numberOfPairsFullyContained);
        }

        private static int numberOfPairsOverlapping = 0;
        public static void SolveSecond()
        {
            foreach (var row in inputRows)
            {
                var elves = row.Split(",");

                var elf1Assignments = elves[0].Split("-");
                var elf2Assignments = elves[1].Split("-");

                var overlapping = isOverlapping(elf1Assignments, elf2Assignments);

                if (overlapping)
                    numberOfPairsOverlapping++;
            }

            Console.WriteLine(numberOfPairsOverlapping);
        }

        private static bool isFullyContained(string[] elf1, string[] elf2)
        {
            if (Int32.Parse(elf1[0]) <= Int32.Parse(elf2[0]) && Int32.Parse(elf1[1]) >= Int32.Parse(elf2[1]))
                return true;

            if (Int32.Parse(elf2[0]) <= Int32.Parse(elf1[0]) && Int32.Parse(elf2[1]) >= Int32.Parse(elf1[1]))
                return true;

            return false;
        }

        private static bool isOverlapping(string[] elf1, string[] elf2)
        {
            var elf1Low = Int32.Parse(elf1[0]);
            var elf1High = Int32.Parse(elf1[1]);
            var elf2Low = Int32.Parse(elf2[0]);
            var elf2High = Int32.Parse(elf2[1]);

            //Console.WriteLine("Elf1Low: " + elf1Low.ToString() + "  Elf1High: " + elf1High + "  Elf2Low: " + elf2Low + " Elf2High: " + elf2High);

            if (elf1Low > elf2Low && elf1Low > elf2High)
                return false;

            if (elf2Low > elf1Low && elf2Low > elf1High)
                return false;

            return true;
        }
    }
}
