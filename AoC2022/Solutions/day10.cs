using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022.Solutions
{
    public class day10
    {
        private static readonly string[] input = File.ReadAllLines(@"../../../Inputs/10.txt");

        private static int X = 1;
        private static int nextCycleAdd = 0;
        private static int cycleNumber = 0;
        private static int inputNumber = 0;
        private static bool isExecuting = false;
        private static int totalSignalStrength = 0;
        private static List<int> cyclesToCheck = new List<int>() { 20, 60, 100, 140, 180, 220 };

        public static void SolveFirst()
        {
            while (true)
            {
                if (inputNumber > input.Length - 1 && !isExecuting) break;
                cycleNumber++;

                if (cyclesToCheck.Contains(cycleNumber))
                    totalSignalStrength += (X * cycleNumber);

                if (isExecuting)
                {
                    
                    X += nextCycleAdd;
                    nextCycleAdd = 0;
                    isExecuting = false;
                    continue;
                }
                if (inputNumber > input.Length - 1) break;
                var command = input[inputNumber].Split(" ");


                if (command[0] == "noop")
                {
                    
                    inputNumber++;
                }
                if (command[0] == "addx")
                {
                    nextCycleAdd = Int32.Parse(command[1]);
                    inputNumber++;
                    isExecuting = true;
                }
            }
            Console.WriteLine(totalSignalStrength);
        }

        private static string lineOne = "";
        private static string lineTwo = "";
        private static string lineThree = "";
        private static string lineFour = "";
        private static string lineFive = "";
        private static string lineSix = "";


        public static void SolveSecond()
        {
            while (true)
            {
                if (inputNumber > input.Length - 1 && !isExecuting) break;
                cycleNumber++;

                if (isExecuting)
                {
                    X += nextCycleAdd;
                    Draw();
                    nextCycleAdd = 0;
                    isExecuting = false;
                    continue;
                }
                if (inputNumber > input.Length - 1) break;
                var command = input[inputNumber].Split(" ");


                if (command[0] == "noop")
                {

                    inputNumber++;
                }
                if (command[0] == "addx")
                {
                    nextCycleAdd = Int32.Parse(command[1]);
                    inputNumber++;
                    isExecuting = true;
                }
                Draw();
            }
            Console.WriteLine(lineOne);
            Console.WriteLine(lineTwo);
            Console.WriteLine(lineThree);
            Console.WriteLine(lineFour);
            Console.WriteLine(lineFive);
            Console.WriteLine(lineSix);

        }

        private static void Draw()
        {
            if (cycleNumber <= 40 && (cycleNumber == X || cycleNumber == X - 1 || cycleNumber == X + 1))
                lineOne = lineOne + "#";
            if (cycleNumber <= 40 && !(cycleNumber == X || cycleNumber == X - 1 || cycleNumber == X + 1))
                lineOne = lineOne + ".";

            if (cycleNumber > 40 && cycleNumber <= 80 && (cycleNumber-40 == X || cycleNumber-40 == X - 1 || cycleNumber-40 == X + 1))
                lineTwo = lineTwo + "#";
            if (cycleNumber > 40 && cycleNumber <= 80 && !(cycleNumber-40 == X || cycleNumber-40 == X - 1 || cycleNumber-40 == X + 1))
                lineTwo = lineTwo + ".";

            if (cycleNumber > 80 && cycleNumber <= 120 && (cycleNumber-80 == X || cycleNumber-80 == X - 1 || cycleNumber-80 == X + 1))
                lineThree = lineThree + "#";
            if (cycleNumber > 80 && cycleNumber <= 120 && !(cycleNumber-80 == X || cycleNumber-80 == X - 1 || cycleNumber-80 == X + 1))
                lineThree = lineThree + ".";

            if (cycleNumber > 120 && cycleNumber <= 160 && (cycleNumber-120 == X || cycleNumber-120 == X - 1 || cycleNumber-120 == X + 1))
                lineFour = lineFour + "#";
            if (cycleNumber > 120 && cycleNumber <= 160 && !(cycleNumber-120 == X || cycleNumber-120 == X - 1 || cycleNumber-120 == X + 1))
                lineFour = lineFour + ".";

            if (cycleNumber > 160 && cycleNumber <= 200 && (cycleNumber-160 == X || cycleNumber-160 == X - 1 || cycleNumber-160 == X + 1))
                lineFive = lineFive + "#";
            if (cycleNumber > 160 && cycleNumber <= 200 && !(cycleNumber-160 == X || cycleNumber-160 == X - 1 || cycleNumber-160 == X + 1))
                lineFive = lineFive + ".";

            if (cycleNumber > 200 && cycleNumber <= 240 && (cycleNumber-200 == X || cycleNumber-200 == X - 1 || cycleNumber-200 == X + 1))
                lineSix = lineSix + "#";
            if (cycleNumber > 200 && cycleNumber <= 240 && !(cycleNumber-200 == X || cycleNumber-200 == X - 1 || cycleNumber-200 == X + 1))
                lineSix = lineSix + ".";
        }

    }
}
