using System.Text;

namespace AoC2022.Solutions
{
    public class day5
    {
        private static readonly string[] inputRows = File.ReadAllLines(@"../../../Inputs/5.txt");
        private static bool setStacks = true;
        private static List<string> stack1 = new List<string>();
        private static List<string> stack2 = new List<string>();
        private static List<string> stack3 = new List<string>();
        private static List<string> stack4 = new List<string>();
        private static List<string> stack5 = new List<string>();
        private static List<string> stack6 = new List<string>();
        private static List<string> stack7 = new List<string>();
        private static List<string> stack8 = new List<string>();
        private static List<string> stack9 = new List<string>();

        public static void SolveFirst()
        {
            foreach (var row in inputRows)
            {
                if (String.IsNullOrEmpty(row))
                {
                    setStacks = false;
                    continue;
                }

                if (setStacks)
                    AddToStacks(row);

                if (!setStacks)
                    MoveCrates(row);
            }

            Console.WriteLine(WriteOutAnswer());
        }

        public static void SolveSecond()
        {
            foreach (var row in inputRows)
            {
                if (String.IsNullOrEmpty(row))
                {
                    setStacks = false;
                    continue;
                }

                if (setStacks)
                    AddToStacks(row);

                if (!setStacks)
                    MoveCrates2(row);
            }

            Console.WriteLine(WriteOutAnswer());
        }

        private static void AddToStacks(string row)
        {
            var firstStack = row[1].ToString();
            var secondStack = row[5].ToString();
            var thirdStack = row[9].ToString();
            var fourthStack = row[13].ToString();
            var fifthStack = row[17].ToString();
            var sixthStack = row[21].ToString();
            var seventhStack = row[25].ToString();
            var eighthStack = row[29].ToString();
            var ninthStack = row[33].ToString();

            if (firstStack == "1")
                return;

            if (!String.IsNullOrWhiteSpace(firstStack))
                stack1.Add(firstStack);
            if (!String.IsNullOrWhiteSpace(secondStack))
                stack2.Add(secondStack);
            if (!String.IsNullOrWhiteSpace(thirdStack))
                stack3.Add(thirdStack);
            if (!String.IsNullOrWhiteSpace(fourthStack))
                stack4.Add(fourthStack);
            if (!String.IsNullOrWhiteSpace(fifthStack))
                stack5.Add(fifthStack);
            if (!String.IsNullOrWhiteSpace(sixthStack))
                stack6.Add(sixthStack);
            if (!String.IsNullOrWhiteSpace(seventhStack))
                stack7.Add(seventhStack);
            if (!String.IsNullOrWhiteSpace(eighthStack))
                stack8.Add(eighthStack);
            if (!String.IsNullOrWhiteSpace(ninthStack))
                stack9.Add(ninthStack);
        }
        private static void MoveCrates(string row)
        {
            var amounts = row.Split(" ");
            var amount = Int32.Parse(amounts[1]);
            var from = Int32.Parse(amounts[3]);
            var to = Int32.Parse(amounts[5]);

            var fromStack = CopyStack(from);
            var toStack = CopyStack(to);

            for (int i = 0; i < amount; i++)
            {
                var crateToMove = fromStack.First();
                toStack.Insert(0, crateToMove);
                fromStack.RemoveAt(0);
            }
        }

        private static void MoveCrates2(string row)
        {
            var amounts = row.Split(" ");
            var amount = Int32.Parse(amounts[1]);
            var from = Int32.Parse(amounts[3]);
            var to = Int32.Parse(amounts[5]);

            var fromStack = CopyStack(from);
            var toStack = CopyStack(to);

            var cratesToMove = fromStack.Take(amount);
            toStack.InsertRange(0, cratesToMove);
            fromStack.RemoveRange(0, amount);
        }

        private static List<string> CopyStack(int stackNumber)
        {
            switch (stackNumber)
            {
                case 1: return stack1;
                case 2: return stack2;
                case 3: return stack3;
                case 4: return stack4;
                case 5: return stack5;
                case 6: return stack6;
                case 7: return stack7;
                case 8: return stack8;
                case 9: return stack9;
            }
            // Should never get here
            return stack1;
        }

        private static string WriteOutAnswer()
        {
            var builder = new StringBuilder();

            builder.Append(stack1.First());
            builder.Append(stack2.First());
            builder.Append(stack3.First());
            builder.Append(stack4.First());
            builder.Append(stack5.First());
            builder.Append(stack6.First());
            builder.Append(stack7.First());
            builder.Append(stack8.First());
            builder.Append(stack9.First());

            return builder.ToString();
        }
    }
}
