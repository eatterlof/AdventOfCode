namespace AoC2022.Solutions
{
    public class day9
    {
        private static readonly string[] inputRows = File.ReadAllLines(@"../../../Inputs/9.txt");
        private static int Hy = 0;
        private static int Hx = 0;
        private static int Ty = 0;
        private static int Tx = 0;
        private static List<(int,int)> visitedTailPositions = new List<(int, int)>() { (0,0) };

        public static void SolveFirst()
        {
            foreach (var row in inputRows)
            {
                string[] instruction = row.Split(' ');

                Move(instruction);
            }
            var uniqueVisitedLocations = visitedTailPositions.OrderBy(x => x.Item1).Distinct().ToList();
            Console.WriteLine(uniqueVisitedLocations.Count);

        }

        public static void SolveSecond()
        {
            
        }

        private static void Move(string[] instruction)
        {
            var direction = instruction[0];
            var length = Int32.Parse(instruction[1]);

            if (direction == "R") // Flytta huvud höger
            {
                for (int i = 0; i < length; i++)
                {
                    Hy++;
                    if (Hy > Ty + 1 && Hx == Tx) // Om de är på samma rad
                    {
                        Ty++;
                        visitedTailPositions.Add((Ty, Tx));
                    }
                    if (Hy > Ty + 1 && Hx > Tx) // Om huvudet är en rad över
                    {
                        Tx++;
                        Ty++;
                        visitedTailPositions.Add((Ty, Tx));
                    }
                    if (Hy > Ty + 1 && Hx < Tx) // Om huvudet är en rad under
                    {
                        Tx--;
                        Ty++;
                        visitedTailPositions.Add((Ty, Tx));
                    }
                }
            }

            if (direction == "L") // Flytta huvud vänster
            {
                for (int i = 0; i < length; i++)
                {
                    Hy--;
                    if (Hy < Ty - 1 && Hx == Tx) // Om de är på samma rad
                    {
                        Ty--;
                        visitedTailPositions.Add((Ty, Tx));
                    }
                    if (Hy < Ty - 1 && Hx > Tx) // Om huvudet är en rad över
                    {
                        Tx++;
                        Ty--;
                        visitedTailPositions.Add((Ty, Tx));
                    }
                    if (Hy < Ty - 1 && Hx < Tx) // Om huvudet är en rad under
                    {
                        Tx--;
                        Ty--;
                        visitedTailPositions.Add((Ty, Tx));
                    }
                }
            }

            if (direction == "U") // Flytta huvud upp
            {
                for (int i = 0; i < length; i++)
                {
                    Hx++;

                    if (Hx > Tx + 1 && Hy == Ty) // Om de är i samma kolumn
                    {
                        Tx++;
                        visitedTailPositions.Add((Ty, Tx));
                    }

                    if (Hx > Tx + 1 && Hy > Ty) // Om huvudet är en till höger om svansen
                    {
                        Tx++;
                        Ty++;
                        visitedTailPositions.Add((Ty, Tx));
                    }

                    if (Hx > Tx + 1 && Hy < Ty) // Om huvudet är en till vänster om svansen
                    {
                        Tx++;
                        Ty--;
                        visitedTailPositions.Add((Ty, Tx));
                    }
                }
            }

            if (direction == "D") // Flytta huvud ner
            {
                for (int i = 0; i < length; i++)
                {
                    Hx--;

                    if (Hx < Tx - 1 && Hy == Ty) // Om de är i samma kolumn
                    {
                        Tx--;
                        visitedTailPositions.Add((Ty, Tx));
                    }

                    if (Hx < Tx - 1 && Hy > Ty) // Om huvudet är en till höger om svansen
                    {
                        Tx--;
                        Ty++;
                        visitedTailPositions.Add((Ty, Tx));
                    }

                    if (Hx < Tx - 1 && Hy < Ty) // Om huvudet är en till vänster om svansen
                    {
                        Tx--;
                        Ty--;
                        visitedTailPositions.Add((Ty, Tx));
                    }
                }
            }


        }
    }
}
