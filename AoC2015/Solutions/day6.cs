using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2015.Solutions
{
    public class day6
    {
        private static readonly string[] input = File.ReadAllLines(@"../../../Inputs/6.txt").ToArray();
        private static bool[,] lights = new bool[1000, 1000];

        public static void SolveFirst()
        {
            foreach (var instruction in input)
            {
                var words = instruction.Split(" ");

                if (instruction.StartsWith("turn"))
                {
                    var from = words[2];
                    var to = words[4];

                    var fromRow = Int32.Parse(from.Split(",")[0]);
                    var fromCol = Int32.Parse(from.Split(",")[1]);

                    var toRow = Int32.Parse(to.Split(",")[0]);
                    var toCol = Int32.Parse(to.Split(",")[1]);

                    if (instruction.StartsWith("turn on"))
                        TurnOnLights(fromRow, fromCol, toRow, toCol);
                    if (instruction.StartsWith("turn off"))
                        TurnOffLights(fromRow, fromCol, toRow, toCol);
                }

                if (instruction.StartsWith("toggle"))
                {
                    var from = words[1];
                    var to = words[3];

                    var fromRow = Int32.Parse(from.Split(",")[0]);
                    var fromCol = Int32.Parse(from.Split(",")[1]);

                    var toRow = Int32.Parse(to.Split(",")[0]);
                    var toCol = Int32.Parse(to.Split(",")[1]);

                    ToggleLights(fromRow, fromCol, toRow, toCol);
                }
            }

            CountAndPrintAmountOfLightsThatAreOn();
        }

        private static void CountAndPrintAmountOfLightsThatAreOn()
        {
            int amountOfLightThatAreOn = 0;
            for (var i = 0; i < 1000; i++)
            {
                for (var j = 0; j < 1000; j++)
                {
                    if (lights[i,j])
                        amountOfLightThatAreOn++;
                }
            }
            Console.WriteLine(amountOfLightThatAreOn);
        }

        private static void TurnOnLights(int fromRow, int fromCol, int toRow, int toCol)
        {
            for (var i = fromRow; i <= toRow; i++)
            {
                for (var j = fromCol; j <= toCol; j++)
                {
                    lights[i, j] = true;
                }
            }
        }

        private static void TurnOffLights(int fromRow, int fromCol, int toRow, int toCol)
        {
            for (var i = fromRow; i <= toRow; i++)
            {
                for (var j = fromCol; j <= toCol; j++)
                {
                    lights[i, j] = false;
                }
            }
        }

        private static void ToggleLights(int fromRow, int fromCol, int toRow, int toCol)
        {
            for (var i = fromRow; i <= toRow; i++)
            {
                for (var j = fromCol; j <= toCol; j++)
                {
                    lights[i, j] = !lights[i, j];
                }
            }
        }

        private static int[,] lights2 = new int[1000, 1000];

        public static void SolveSecond()
        {
            foreach (var instruction in input)
            {
                var words = instruction.Split(" ");

                if (instruction.StartsWith("turn"))
                {
                    var from = words[2];
                    var to = words[4];

                    var fromRow = Int32.Parse(from.Split(",")[0]);
                    var fromCol = Int32.Parse(from.Split(",")[1]);

                    var toRow = Int32.Parse(to.Split(",")[0]);
                    var toCol = Int32.Parse(to.Split(",")[1]);

                    if (instruction.StartsWith("turn on"))
                        IncreaseLights(fromRow, fromCol, toRow, toCol);
                    if (instruction.StartsWith("turn off"))
                        DecreaseLights(fromRow, fromCol, toRow, toCol);
                }

                if (instruction.StartsWith("toggle"))
                {
                    var from = words[1];
                    var to = words[3];

                    var fromRow = Int32.Parse(from.Split(",")[0]);
                    var fromCol = Int32.Parse(from.Split(",")[1]);

                    var toRow = Int32.Parse(to.Split(",")[0]);
                    var toCol = Int32.Parse(to.Split(",")[1]);

                    DoubleIncreaseLights(fromRow, fromCol, toRow, toCol);
                }
            }

            CountAndPrintTotalBrightness();
        }

        private static void CountAndPrintTotalBrightness()
        {
            int amountOfLightThatAreOn = 0;
            for (var i = 0; i < 1000; i++)
            {
                for (var j = 0; j < 1000; j++)
                {
                    amountOfLightThatAreOn = amountOfLightThatAreOn + lights2[i, j];
                }
            }
            Console.WriteLine(amountOfLightThatAreOn);
        }

        private static void IncreaseLights(int fromRow, int fromCol, int toRow, int toCol)
        {
            for (var i = fromRow; i <= toRow; i++)
            {
                for (var j = fromCol; j <= toCol; j++)
                {
                    lights2[i, j] = lights2[i, j] + 1;
                }
            }
        }

        private static void DecreaseLights(int fromRow, int fromCol, int toRow, int toCol)
        {
            for (var i = fromRow; i <= toRow; i++)
            {
                for (var j = fromCol; j <= toCol; j++)
                {
                    if (lights2[i, j] > 0)
                        lights2[i, j] = lights2[i, j] - 1;
                }
            }
        }

        private static void DoubleIncreaseLights(int fromRow, int fromCol, int toRow, int toCol)
        {
            for (var i = fromRow; i <= toRow; i++)
            {
                for (var j = fromCol; j <= toCol; j++)
                {
                    lights2[i, j] = lights2[i, j] + 2;
                }
            }
        }

    }
}
