using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2015.Solutions
{
    public class day7
    {
        private static readonly string[] inputLines = File.ReadAllLines(@"../../../Inputs/7.txt").ToArray();
        private static Dictionary<string, int> wires = new Dictionary<string, int>();

        public static void SolveFirst()
        {
            foreach (var line in inputLines)
            {
                var operation = line.Split(" ");

                if (operation[0] == "NOT")
                {
                    PerformNotOperation(operation);
                    continue;
                }

                if (operation[1] == "OR")
                {
                    PerformOrOperation(operation);
                    continue;
                }

                if (operation[1] == "AND")
                {
                    PerformAndOperation(operation);
                    continue;
                }

                if (operation[1] == "RSHIFT")
                {
                    PerformRShiftOperation(operation);
                    continue;
                }

                if (operation[1] == "LSHIFT")
                {
                    PerformLShiftOperation(operation);
                    continue;
                }

                else
                {
                    PerformNormalOperation(operation);
                    continue;
                }
            }

            foreach (var wire in wires)
                Console.WriteLine(wire.ToString());
        }

        private static void PerformLShiftOperation(string[] operation)
        {
            wires.TryGetValue(operation[0], out int value1);
            wires.TryGetValue(operation[2], out int value2);

            var bit1 = Convert.ToInt16(value1);
            var bit2 = Convert.ToInt16(value2);

            var result = bit1 << bit2;

            var wireKey = operation[4];
            wires.Add(wireKey, result);
        }

        private static void PerformRShiftOperation(string[] operation)
        {
            wires.TryGetValue(operation[0], out int value1);
            wires.TryGetValue(operation[2], out int value2);

            var bit1 = Convert.ToInt16(value1);
            var bit2 = Convert.ToInt16(value2);

            var result = bit1 >> bit2;

            var wireKey = operation[4];
            wires.Add(wireKey, result);
        }

        private static void PerformAndOperation(string[] operation)
        {
            wires.TryGetValue(operation[0], out int value1);
            wires.TryGetValue(operation[2], out int value2);

            var bit1 = Convert.ToInt16(value1);
            var bit2 = Convert.ToInt16(value2);

            var result = bit1 & bit2;

            var wireKey = operation[4];
            wires.Add(wireKey, result);
        }

        private static void PerformOrOperation(string[] operation)
        {
            wires.TryGetValue(operation[0], out int value1);
            wires.TryGetValue(operation[2], out int value2);

            var bit1 = Convert.ToInt16(value1);
            var bit2 = Convert.ToInt16(value2);

            var result = bit1 | bit2;

            var wireKey = operation[4];
            wires.Add(wireKey, result);
        }

        private static void PerformNotOperation(string[] operation)
        {
            wires.TryGetValue(operation[1], out int value);

            var bit = Convert.ToInt16(value);

            var result = ~bit;

            var wireKey = operation[3];
            wires.Add(wireKey, result);
        }

        private static void PerformNormalOperation(string[] operation)
        {
            var wireKey = operation[2];
            var value = Int32.Parse(operation[0]);
            wires.Add(wireKey, value);
        }

        public static void SolveSecond()
        {
        }

    }
}
