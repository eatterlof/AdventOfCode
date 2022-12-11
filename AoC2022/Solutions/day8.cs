namespace AoC2022.Solutions
{
    public class day8
    {
        private static readonly string[] input = File.ReadAllLines(@"../../../Inputs/8.txt");
        private static List<List<int>> treeRows = new List<List<int>>();
        private static int amountOfVisibleTrees = 0;

        public static void SolveFirst()
        {
            foreach (var row in input)
            {
                var treeList = new List<int>();

                foreach (var character in row)
                {
                    treeList.Add(Int32.Parse(character.ToString()));
                }
                treeRows.Add(treeList);
            }

            HowManyTreesAreVisible();

            Console.WriteLine(amountOfVisibleTrees);
        }

        public static void SolveSecond()
        {

        }

        private static void HowManyTreesAreVisible()
        {
            for (int i = 0; i < treeRows.Count; i++) // För varje rad med träd
            {
                var row = treeRows[i];
                var biggestTree = 0;

                for (int j = 0; j < row.Count; j++) // För varje träd i raden
                {
                    var visible = true;
                    var tree = row[j];

                    if (j == 0)
                        biggestTree = tree;

                    if (i == 0) // Första raden syns alltid
                    {
                        amountOfVisibleTrees++;
                        continue;
                    }

                    if (i+1 == treeRows.Count) // Sista raden syns alltid
                    {
                        amountOfVisibleTrees++;
                        continue;
                    }

                    if (j == 0) // Första trädet i varje rad syns alltid
                    {
                        amountOfVisibleTrees++;
                        continue;
                    }

                    if (j+1 == row.Count) // Sista trädet i varje rad syns alltid
                    {
                        amountOfVisibleTrees++;
                        continue;
                    }

                    if (tree > biggestTree) // Kollar vänster
                    {
                        biggestTree = tree;
                        amountOfVisibleTrees++;
                        continue;
                    }

                    for (int x = j+1; x < row.Count; x++) // Kollar höger
                        if (tree <= row[x])
                            visible = false;

                    if (visible)
                    {
                        amountOfVisibleTrees++;
                        continue;
                    }

                    for (int y = 0; y < j; y++) // Kolla uppåt
                        if (tree <= treeRows[y][j])
                            visible = false;

                    if (visible)
                    {
                        amountOfVisibleTrees++;
                        continue;
                    }

                    for (int z = j; z < treeRows.Count; z++) // Kolla nedåt
                        if (tree <= treeRows[z][j])
                            visible = false;

                    if (visible)
                    {
                        amountOfVisibleTrees++;
                        continue;
                    }
                }
            }
        }

    }
}
