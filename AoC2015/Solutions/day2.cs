using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2015.Solutions
{
    public class day2
    {
        private static readonly string[] inputRows = File.ReadLines(@"../../../Inputs/2.txt").ToArray();

        public static void SolveFirst()
        {
            var squareFeetOfPaperToOrder = 0;

            foreach (var row in inputRows)
            {
                var lengths = row.Split("x");

                squareFeetOfPaperToOrder += CalculatePaperNeeded(Int32.Parse(lengths[0]), Int32.Parse(lengths[1]), Int32.Parse(lengths[2]));
            }

            Console.WriteLine(squareFeetOfPaperToOrder.ToString());
        }

        private static int CalculatePaperNeeded(int length, int width, int height)
        {
            var sides = length * width;
            var frontAndBack = width * height;
            var topAndBottom = height * length;

            var a = 2 * sides;
            var b = 2 * frontAndBack;
            var c = 2 * topAndBottom;

            int smallestPart = SmallestPart(sides, frontAndBack, topAndBottom);

            int paper = a+b+c+smallestPart;

            return paper;
        }

        private static int SmallestPart(int x, int y, int z)
        {
            int min = x;

            if (x <= y && x <= z)
                min = x;
            if (y <= x && y <= z)
                min = y;
            if (z <= x && z <= y)
                min = z;

            return min;
        }

        public static void SolveSecond()
        {
            var squareFeetOfRibbonToOrder = 0;

            foreach (var row in inputRows)
            {
                var lengths = row.Split("x");

                squareFeetOfRibbonToOrder += CalculateRibbonNeeded(Int32.Parse(lengths[0]), Int32.Parse(lengths[1]), Int32.Parse(lengths[2]));
            }

            Console.WriteLine(squareFeetOfRibbonToOrder.ToString());
        }

        private static int CalculateRibbonNeeded(int length, int width, int height)
        {
            var twoShortestLengths = TwoShortestLenghts(length, width, height);

            var a = twoShortestLengths.FirstOrDefault();
            var b = twoShortestLengths.LastOrDefault();

            int ribbon = a+a+b+b;

            int bow = length * width * height;

            return ribbon + bow;
        }

        private static List<int> TwoShortestLenghts(int a, int b, int c)
        {
            var list = new List<int>() { a, b, c };

            list.Sort();

            list.RemoveAt(2);

            return list;
        }
    }
}
