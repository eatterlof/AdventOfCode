using System;
using System.IO;
using System.Linq;

namespace Aoc2024.Solutions
{
    public class day4
    {
        public static void SolveFirst()
        {
            var inputRows = File.ReadAllLines(@"../../../Inputs/4.txt");

            string sequence = "XMAS";
            int count = CountSequenceOccurrences(inputRows, sequence);
            Console.WriteLine($"Sequence found {count} times.");
        }

        public static void SolveSecond()
        {
            var inputRows = File.ReadAllLines(@"../../../Inputs/4.txt");

            char[,] pattern1 = {
                { 'M', '.', 'S' },
                { '.', 'A', '.' },
                { 'M', '.', 'S' }
            };

            char[,] pattern2 = {
                { 'M', '.', 'M' },
                { '.', 'A', '.' },
                { 'S', '.', 'S' }
            };

            char[,] pattern3 = {
                { 'S', '.', 'M' },
                { '.', 'A', '.' },
                { 'S', '.', 'M' }
            };

            char[,] pattern4 = {
                { 'S', '.', 'S' },
                { '.', 'A', '.' },
                { 'M', '.', 'M' }
            };

            int count = CountPatternOccurrences(inputRows, pattern1) +
                        CountPatternOccurrences(inputRows, pattern2) +
                        CountPatternOccurrences(inputRows, pattern3) +
                        CountPatternOccurrences(inputRows, pattern4);

            Console.WriteLine($"Pattern found {count} times.");
        }

        static int CountSequenceOccurrences(string[] list, string sequence)
        {
            int count = 0;

            // Left-to-Right
            foreach (var str in list)
            {
                count += CountOccurrences(str, sequence);
            }

            // Right-to-Left
            foreach (var str in list)
            {
                var reversedStr = ReverseString(str);
                count += CountOccurrences(reversedStr, sequence);
            }

            // Top-to-Bottom
            int maxLength = list.Max(str => str.Length);
            for (int col = 0; col < maxLength; col++)
            {
                string columnString = "";
                for (int row = 0; row < list.Length; row++)
                {
                    if (col < list[row].Length)
                    {
                        columnString += list[row][col];
                    }
                }
                count += CountOccurrences(columnString, sequence);
            }

            // Bottom-to-Top
            for (int col = 0; col < maxLength; col++)
            {
                string columnString = "";
                for (int row = list.Length - 1; row >= 0; row--)
                {
                    if (col < list[row].Length)
                    {
                        columnString += list[row][col];
                    }
                }
                count += CountOccurrences(columnString, sequence);
            }

            // Diagonals
            count += CountDiagonalOccurrences(list, sequence, 1, 1);  // Top-Left to Bottom-Right
            count += CountDiagonalOccurrences(list, sequence, 1, -1); // Top-Right to Bottom-Left
            count += CountDiagonalOccurrences(list, sequence, -1, 1); // Bottom-Left to Top-Right
            count += CountDiagonalOccurrences(list, sequence, -1, -1); // Bottom-Right to Top-Left

            return count;
        }

        static int CountOccurrences(string str, string sequence)
        {
            int count = 0;
            int index = str.IndexOf(sequence);
            while (index != -1)
            {
                count++;
                index = str.IndexOf(sequence, index + 1);
            }
            return count;
        }

        static int CountDiagonalOccurrences(string[] list, string sequence, int rowIncrement, int colIncrement)
        {
            int count = 0;
            int maxLength = list.Max(str => str.Length);
            int sequenceLength = sequence.Length;

            for (int row = 0; row < list.Length; row++)
            {
                for (int col = 0; col < maxLength; col++)
                {
                    string diagonalString = "";
                    for (int j = 0; j < sequenceLength; j++)
                    {
                        int newRow = row + j * rowIncrement;
                        int newCol = col + j * colIncrement;

                        if (newRow >= 0 && newRow < list.Length && newCol >= 0 && newCol < maxLength && newCol < list[newRow].Length)
                        {
                            diagonalString += list[newRow][newCol];
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (diagonalString == sequence)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        static int CountPatternOccurrences(string[] list, char[,] pattern)
        {
            int count = 0;
            int patternRows = pattern.GetLength(0);
            int patternCols = pattern.GetLength(1);

            for (int row = 0; row <= list.Length - patternRows; row++)
            {
                for (int col = 0; col <= list[0].Length - patternCols; col++)
                {
                    if (IsPatternMatch(list, pattern, row, col))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        static bool IsPatternMatch(string[] list, char[,] pattern, int startRow, int startCol)
        {
            int patternRows = pattern.GetLength(0);
            int patternCols = pattern.GetLength(1);

            for (int row = 0; row < patternRows; row++)
            {
                for (int col = 0; col < patternCols; col++)
                {
                    int currentRow = startRow + row;
                    int currentCol = startCol + col;

                    // Check if the current position is within the bounds of the grid
                    if (currentRow >= list.Length || currentCol >= list[currentRow].Length)
                    {
                        return false;
                    }

                    if (pattern[row, col] != '.' && pattern[row, col] != list[currentRow][currentCol])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static string ReverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
