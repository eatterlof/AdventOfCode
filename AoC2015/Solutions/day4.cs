using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2015.Solutions
{
    public class day4
    {
        private static readonly string input = File.ReadAllText(@"../../../Inputs/4.txt");
        private static int number = 0;

        public static void SolveFirst()
        {
            for (int i = number; i < 1000000; i++)
            {
                var inputText = input + i;

                var test = CreateMD5(inputText);

                if (test.StartsWith("00000"))
                {
                    Console.WriteLine(i);
                    break;
                }
            }
            
        }

        public static void SolveSecond()
        {
            for (int i = number; i < 10000000; i++)
            {
                var inputText = input + i;

                var test = CreateMD5(inputText);

                if (test.StartsWith("000000"))
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }

        public static string CreateMD5(string input) // as per: https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5?redirectedfrom=MSDN&view=net-7.0
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                string result = Convert.ToHexString(hashBytes);
                return result; 
            }
        }

    }
}