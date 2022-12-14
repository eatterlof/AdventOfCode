namespace AoC2022.Solutions
{
    public class day9
    {
        private static readonly string[] inputRows = File.ReadAllLines(@"../../../Inputs/9.txt");
        private static int Hy = 0;
        private static int Hx = 0;
        private static int Ty = 0;
        private static int Tx = 0;
        private static int T2y = 0;
        private static int T2x = 0;
        private static int T3y = 0;
        private static int T3x = 0;
        private static int T4y = 0;
        private static int T4x = 0;
        private static int T5y = 0;
        private static int T5x = 0;
        private static int T6y = 0;
        private static int T6x = 0;
        private static int T7y = 0;
        private static int T7x = 0;
        private static int T8y = 0;
        private static int T8x = 0;
        private static int T9y = 0;
        private static int T9x = 0;
        private static List<(int, int)> visitedTailPositions = new List<(int, int)>() { (0, 0) };

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
            foreach (var row in inputRows)
            {
                string[] instruction = row.Split(' ');
                var direction = instruction[0];
                var length = Int32.Parse(instruction[1]);

                for (int i = 0; i < length; i++)
                {
                    MoveHead(direction);
                    var first = MoveTail(Hx, Hy, Tx, Ty);
                    Tx = first[0];
                    Ty = first[1];
                    var second = MoveTail(Tx, Ty, T2x, T2y);
                    T2x = second[0];
                    T2y = second[1];
                    var third = MoveTail(T2x, T2y, T3x, T3y);
                    T3x = third[0];
                    T3y= third[1];
                    var fourth = MoveTail(T3x, T3y, T4x, T4y);
                    T4x = fourth[0];
                    T4y= fourth[1];
                    var fifth = MoveTail(T4x, T4y,T5x, T5y);
                    T5x = fifth[0];
                    T5y = fifth[1];
                    var sixth = MoveTail(T5x,T5y, T6x, T6y);
                    T6x = sixth[0];
                    T6y = sixth[1];
                    var seventh = MoveTail(T6x, T6y, T7x, T7y);
                    T7x = seventh[0];
                    T7y = seventh[1];
                    var eighth = MoveTail(T7x, T7y, T8x, T8y);
                    T8x = eighth[0];
                    T8y = eighth[1];
                    var ninth = MoveTail(T8x, T8y, T9x, T9y);
                    T9x = ninth[0];
                    T9y = ninth[1];
                    if (!visitedTailPositions.Contains((T9x, T9y)))
                        visitedTailPositions.Add((T9x, T9y));
                }
            }
            Console.WriteLine(visitedTailPositions.Count);
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

        private static void MoveHead(string direction)
        {

            if (direction == "R") // Flytta höger
                Hy++;

            if (direction == "L") // Flytta vänster
                Hy--;

            if (direction == "U") // Flytta upp
                Hx++;

            if (direction == "D") // Flytta ner
                Hx--;
        }
        private static int[] MoveTail(int headX, int headY, int tailX, int tailY)
        {
            // Höger
            if (headY > tailY + 1 && headX == tailX) // Om de är på samma rad
            {
                tailY++;
            }
            if (headY > tailY + 1 && headX > tailX) // Om huvudet är en rad över
            {
                tailX++;
                tailY++;
            }
            if (headY > tailY + 1 && headX < tailX) // Om huvudet är en rad under
            {
                tailX--;
                tailY++;
            }

            // Vänster
            if (headY < tailY - 1 && headX == tailX) // Om de är på samma rad
            {
                tailY--;
            }
            if (headY < tailY - 1 && headX > tailX) // Om huvudet är en rad över
            {
                tailX++;
                tailY--;
            }
            if (headY < tailY - 1 && headX < tailX) // Om huvudet är en rad under
            {
                tailX--;
                tailY--;
            }

            // Upp
            if (headX > tailX + 1 && headY == tailY) // Om de är i samma kolumn
            {
                tailX++;
            }

            if (headX > tailX + 1 && headY > tailY) // Om huvudet är en till höger om svansen
            {
                tailX++;
                tailY++;
            }

            if (headX > tailX + 1 && headY < tailY) // Om huvudet är en till vänster om svansen
            {
                tailX++;
                tailY--;
            }

            // ner
            if (headX < tailX - 1 && headY == tailY) // Om de är i samma kolumn
            {
                tailX--;
            }

            if (headX < tailX - 1 && headY > tailY) // Om huvudet är en till höger om svansen
            {
                tailX--;
                tailY++;
            }

            if (headX < tailX - 1 && headY < tailY) // Om huvudet är en till vänster om svansen
            {
                tailX--;
                tailY--;
            }

            int[] endLocation = new int[] {tailX, tailY};
            return endLocation;
        }
    }
}
