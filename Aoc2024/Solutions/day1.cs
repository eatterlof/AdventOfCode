namespace Aoc2024.Solutions
{
    public class day1
    {
        public static void SolveFirst()
        {
            var inputRows = File.ReadAllLines(@"../../../Inputs/1.txt");

            List<int> leftSide = new List<int>();
            List<int> rightSide = new List<int>();

            // Process each string in the input list
            foreach (string line in inputRows)
            {
                // Split the string into parts by whitespace
                string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                // Add the parts to the respective lists
                if (parts.Length == 2)
                {
                    leftSide.Add(int.Parse(parts[0]));
                    rightSide.Add(int.Parse(parts[1]));
                }
            }

            leftSide.Sort();
            rightSide.Sort();

            int totalDistance = 0;

            for (int i = 0; i < leftSide.Count; i++)
            {
                var digitA = leftSide[i];
                var digitB = rightSide[i];

                if (digitA > digitB)
                {
                    var distance = digitA - digitB;
                    totalDistance += distance;
                }
                if (digitA < digitB)
                {
                    var distance = digitB - digitA;
                    totalDistance += distance;
                }
            }

            Console.WriteLine(totalDistance.ToString());
        }

        public static void SolveSecond()
        {
            var inputRows = File.ReadAllLines(@"../../../Inputs/1.txt");

            List<int> leftSide = new List<int>();
            List<int> rightSide = new List<int>();

            // Process each string in the input list
            foreach (string line in inputRows)
            {
                // Split the string into parts by whitespace
                string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                // Add the parts to the respective lists
                if (parts.Length == 2)
                {
                    leftSide.Add(int.Parse(parts[0]));
                    rightSide.Add(int.Parse(parts[1]));
                }
            }

            int totalScore = 0;

            foreach (var number in leftSide)
            {
                int count = rightSide.Count(n => n == number);

                var similarityScore = number * count;

                totalScore += similarityScore;
            }

            Console.WriteLine(totalScore.ToString());
        }
    }
}
