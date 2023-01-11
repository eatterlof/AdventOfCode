namespace AoC2015.Solutions
{
    public class day1
    {
        private static readonly string input = File.ReadAllText(@"../../../Inputs/1.txt");

        public static void SolveFirst()
        {
            var floor = 0;
            foreach (var character in input)
            {
                if (character.ToString() == "(")
                    floor++;

                if (character.ToString() == ")")
                    floor--;
            }
        }

        public static void SolveSecond()
        {
            var floor = 0;
            var position = 0;
            foreach (var character in input)
            {
                if (character.ToString() == "(")
                    floor++;

                if (character.ToString() == ")")
                    floor--;

                position++;

                if (floor == -1)
                    break;
            }
        }
    }
}
