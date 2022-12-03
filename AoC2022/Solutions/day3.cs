using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022.Solutions
{
    public class day3
    {
        private static readonly string[] inputRows = File.ReadAllLines(@"../../../Inputs/3.txt");
        private static int prioritySum = 0;
        public static void SolveFirst()
        {
            foreach (var row in inputRows)
            {

                var firstCompartment = row.Substring(0, (int)(row.Length / 2)).ToCharArray();
                var secondCompartment = row.Substring((int)(row.Length / 2), (int)(row.Length / 2)).ToCharArray();

                foreach (var item in firstCompartment)
                    if (secondCompartment.Contains(item))
                    {
                        AddScore(item.ToString());
                        break;
                    }

            }
            Console.WriteLine(prioritySum);
        }

        public static char[] firstElf = null;
        public static char[] secondElf = null;
        public static char[] thirdElf = null;

        public static void SolveSecond()
        {
            foreach (var row in inputRows)
            {
                if (firstElf == null)
                {
                    firstElf = row.ToCharArray();
                    continue;
                }
                if (secondElf == null)
                {
                    secondElf = row.ToCharArray();
                    continue;
                }
                if (thirdElf == null)
                {
                    thirdElf = row.ToCharArray();

                    foreach (var item in firstElf)
                        if (secondElf.Contains(item) && thirdElf.Contains(item))
                        {
                            AddScore(item.ToString());
                            break;
                        }

                    firstElf = null;
                    secondElf = null;
                    thirdElf = null;
                }
            }
            Console.WriteLine(prioritySum);
        }

        private static void AddScore(string item)
        {
            switch (item)
            {
                case "a":
                    prioritySum = prioritySum + 1;
                    break;
                case "b":
                    prioritySum = prioritySum + 2;
                    break;
                case "c":
                    prioritySum = prioritySum + 3;
                    break;
                case "d":
                    prioritySum = prioritySum + 4;
                    break;
                case "e":
                    prioritySum = prioritySum + 5;
                    break;
                case "f":
                    prioritySum = prioritySum + 6;
                    break;
                case "g":
                    prioritySum = prioritySum + 7;
                    break;
                case "h":
                    prioritySum = prioritySum + 8;
                    break;
                case "i":
                    prioritySum = prioritySum + 9;
                    break;
                case "j":
                    prioritySum = prioritySum + 10;
                    break;
                case "k":
                    prioritySum = prioritySum + 11;
                    break;
                case "l":
                    prioritySum = prioritySum + 12;
                    break;
                case "m":
                    prioritySum = prioritySum + 13;
                    break;
                case "n":
                    prioritySum = prioritySum + 14;
                    break;
                case "o":
                    prioritySum = prioritySum + 15;
                    break;
                case "p":
                    prioritySum = prioritySum + 16;
                    break;
                case "q":
                    prioritySum = prioritySum + 17;
                    break;
                case "r":
                    prioritySum = prioritySum + 18;
                    break;
                case "s":
                    prioritySum = prioritySum + 19;
                    break;
                case "t":
                    prioritySum = prioritySum + 20;
                    break;
                case "u":
                    prioritySum = prioritySum + 21;
                    break;
                case "v":
                    prioritySum = prioritySum + 22;
                    break;
                case "w":
                    prioritySum = prioritySum + 23;
                    break;
                case "x":
                    prioritySum = prioritySum + 24;
                    break;
                case "y":
                    prioritySum = prioritySum + 25;
                    break;
                case "z":
                    prioritySum = prioritySum + 26;
                    break;
                case "A":
                    prioritySum = prioritySum + 27;
                    break;
                case "B":
                    prioritySum = prioritySum + 28;
                    break;
                case "C":
                    prioritySum = prioritySum + 29;
                    break;
                case "D":
                    prioritySum = prioritySum + 30;
                    break;
                case "E":
                    prioritySum = prioritySum + 31;
                    break;
                case "F":
                    prioritySum = prioritySum + 32;
                    break;
                case "G":
                    prioritySum = prioritySum + 33;
                    break;
                case "H":
                    prioritySum = prioritySum + 34;
                    break;
                case "I":
                    prioritySum = prioritySum + 35;
                    break;
                case "J":
                    prioritySum = prioritySum + 36;
                    break;
                case "K":
                    prioritySum = prioritySum + 37;
                    break;
                case "L":
                    prioritySum = prioritySum + 38;
                    break;
                case "M":
                    prioritySum = prioritySum + 39;
                    break;
                case "N":
                    prioritySum = prioritySum + 40;
                    break;
                case "O":
                    prioritySum = prioritySum + 41;
                    break;
                case "P":
                    prioritySum = prioritySum + 42;
                    break;
                case "Q":
                    prioritySum = prioritySum + 43;
                    break;
                case "R":
                    prioritySum = prioritySum + 44;
                    break;
                case "S":
                    prioritySum = prioritySum + 45;
                    break;
                case "T":
                    prioritySum = prioritySum + 46;
                    break;
                case "U":
                    prioritySum = prioritySum + 47;
                    break;
                case "V":
                    prioritySum = prioritySum + 48;
                    break;
                case "W":
                    prioritySum = prioritySum + 49;
                    break;
                case "X":
                    prioritySum = prioritySum + 50;
                    break;
                case "Y":
                    prioritySum = prioritySum + 51;
                    break;
                case "Z":
                    prioritySum = prioritySum + 52;
                    break;


            }
        }
    }
}
