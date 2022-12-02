using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022.Solutions
{
    public class day2
    {
        private static string elf = "";
        private static string me = "";
        private static int score = 0;
        private static readonly string[] inputRows = File.ReadAllLines(@"../../../Inputs/2.txt");

        public static void SolveFirst()
        {
            foreach (var row in inputRows)
            {
                string[] result = row.Split(" ");

                GiveElfAndMeRockPaperOrScissor1(result);

                CalculateGame(elf, me);
            }
            Console.WriteLine("Score " + score);
        }

        public static void SolveSecond()
        {
            foreach (var row in inputRows)
            {
                string[] result = row.Split(" ");

                GiveElfAndMeRockPaperOrScissor2(result);

                CalculateGame(elf, me);
            }
            Console.WriteLine("Score " + score);
        }

        private static void GiveElfAndMeRockPaperOrScissor1(string[] letters)
        {
            if (letters[0] == "A")
                elf = "Rock";

            if (letters[0] == "B")
                elf = "Paper";

            if (letters[0] == "C")
                elf = "Scissors";

            if (letters[1] == "X")
                me = "Rock";

            if (letters[1] == "Y")
                me = "Paper";

            if (letters[1] == "Z")
                me = "Scissors";
        }

        private static void GiveElfAndMeRockPaperOrScissor2(string[] letters)
        {
            if (letters[0] == "A")
                elf = "Rock";

            if (letters[0] == "B")
                elf = "Paper";

            if (letters[0] == "C")
                elf = "Scissors";

            if (letters[1] == "X")
            {
                if (elf == "Rock")
                    me = "Scissors";

                if (elf == "Paper")
                    me = "Rock";

                if (elf == "Scissors")
                    me = "Paper";
            }

            if (letters[1] == "Y")
            {
                if (elf == "Rock")
                    me = "Rock";

                if (elf == "Paper")
                    me = "Paper";

                if (elf == "Scissors")
                    me = "Scissors";
            }

            if (letters[1] == "Z")
            {
                if (elf == "Rock")
                    me = "Paper";

                if (elf == "Paper")
                    me = "Scissors";

                if (elf == "Scissors")
                    me = "Rock";
            }
        }

        private static void CalculateGame(string elf, string me)
        {
            string outcome = "";

            if (elf == me)
                outcome = "draw";

            if (elf == "Rock" && me == "Paper")
                outcome = "win";

            if (elf == "Rock" && me == "Scissors")
                outcome = "lose";

            if (elf == "Paper" && me == "Scissors")
                outcome = "win";

            if (elf == "Paper" && me == "Rock")
                outcome = "lose";

            if (elf == "Scissors" && me == "Paper")
                outcome = "lose";

            if (elf == "Scissors" && me == "Rock")
                outcome = "win";

            if (me == "Rock")
                score += 1;

            if (me == "Paper")
                score += 2;

            if (me == "Scissors")
                score += 3;

            if (outcome == "lose")
                score += 0;

            if (outcome == "draw")
                score += 3;

            if (outcome == "win")
                score += 6;
        }
    }
}
