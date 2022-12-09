namespace AoC2022.Solutions
{
    public class day8
    {
        private static readonly string[] input = File.ReadAllLines(@"../../../Inputs/8.txt");
        private static List<List<int>> treeRows = new List<List<int>>();

        public static void SolveFirst()
        {
            foreach (var row in input)
            {
                var newList = new List<int>();

                foreach (var character in row)
                {
                    newList.Add(Int32.Parse(character.ToString()));
                }
                treeRows.Add(newList);
            }

            HowManyTreesAreVisible();
        }

        public static void SolveSecond()
        {
            
        }

        private static void HowManyTreesAreVisible()
        {

        }
    }
}
