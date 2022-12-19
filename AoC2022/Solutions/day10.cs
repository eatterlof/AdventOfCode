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


        public static void SolveFirst()
        {
            var test = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var command = input[i].Split(" ");
                Console.WriteLine(command);
            }
        }


        public static void SolveSecond()
        {

        }
    }
}
