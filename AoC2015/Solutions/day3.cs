using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2015.Solutions
{
    public class day3
    {
        private static readonly char[] input = File.ReadAllText(@"../../../Inputs/3.txt").ToArray();
        private static List<int[]> housesVisited = new List<int[]>();
        private static int amountOfHousesVisited = 0;
        private static int currentHouseX = 0;
        private static int currentHouseY = 0;

        public static void SolveFirst()
        {
            housesVisited.Add(new int[] { 0, 0 });
            amountOfHousesVisited++;

            foreach (var direction in input)
            {
                MoveSanta(direction);
                DeliverToHouse(direction);
            }

            Console.WriteLine(amountOfHousesVisited);
        }

        private static void MoveSanta(char direction)
        {
            if (direction.ToString() == "^")
                currentHouseX++;

            if (direction.ToString() == "v")
                currentHouseX--;

            if (direction.ToString() == "<")
                currentHouseY--;

            if (direction.ToString() == ">")
                currentHouseY++;

        }

        private static void DeliverToHouse(char direction)
        {
            var currentHouse = new int[] { currentHouseX, currentHouseY };

            var isInList = false;

            foreach (var house in housesVisited)
            {
                isInList = CompareHousePosition(house, currentHouse);
                if (isInList)
                    break;
            }

            if (!isInList)
            {
                housesVisited.Add(currentHouse);
                amountOfHousesVisited++;
            }

        }

        private static bool CompareHousePosition(int[] houseInList, int[] currentHouse)
        {
            var isSame = false;

            if (houseInList[0] == currentHouse[0] && houseInList[1] == currentHouse[1])
                isSame = true;

            return isSame;
        }

        private static int santaOrRobo = 1;
        private static int currentRoboHouseX = 0;
        private static int currentRoboHouseY = 0;

        public static void SolveSecond()
        {
            housesVisited.Add(new int[] { 0, 0 });
            amountOfHousesVisited++;

            foreach (var direction in input)
            {
                if (santaOrRobo % 2 == 0)
                {
                    MoveSanta(direction);
                    DeliverToHouse(direction);
                }
                if (santaOrRobo % 2 == 1)
                {
                    MoveRoboSanta(direction);
                    RoboDeliverToHouse(direction);

                }

                santaOrRobo++;
            }

            Console.WriteLine(amountOfHousesVisited);
        }

        private static void MoveRoboSanta(char direction)
        {
            if (direction.ToString() == "^")
                currentRoboHouseX++;

            if (direction.ToString() == "v")
                currentRoboHouseX--;

            if (direction.ToString() == "<")
                currentRoboHouseY--;

            if (direction.ToString() == ">")
                currentRoboHouseY++;

        }

        private static void RoboDeliverToHouse(char direction)
        {
            var currentHouse = new int[] { currentRoboHouseX, currentRoboHouseY };

            var isInList = false;

            foreach (var house in housesVisited)
            {
                isInList = CompareHousePosition(house, currentHouse);
                if (isInList)
                    break;
            }

            if (!isInList)
            {
                housesVisited.Add(currentHouse);
                amountOfHousesVisited++;
            }

        }
    }
}
