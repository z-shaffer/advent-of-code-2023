using System.Text.Json.Serialization;

namespace AdventOfCode2023.Day03
{
    class Program
    {
        static void Main()
        {
            string[] lines = File.ReadAllLines("input.txt");
            char[][] grid = convertToGrid(lines);

            Console.WriteLine("Part 1");
            Console.WriteLine(PartOne(grid));

            Console.WriteLine("Part 2");
            Console.WriteLine(PartTwo(grid));
        }

        static int PartOne(char[][] grid)
        { 
            int sum = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    bool symbolFound = false;
                    string numbers = "";
                    while (j < grid[i].Length && char.IsDigit(grid[i][j]))
                    {
                        if (checkForSymbols(grid, i, j))
                        {
                            symbolFound = true;      
                        }
                        numbers += grid[i][j];
                        j++;
                    }
                    if (symbolFound)
                    {
                        sum += int.Parse(numbers);
                    }
                }
            }
            return sum;
        }

        static int PartTwo(char[][] grid)
        {
            int sum = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    int[] numbers = new int[2];
                    if (grid[i][j] == '*')
                    {
                        numbers = checkForNumbers(grid, i, j);
                        sum += numbers[0] * numbers[1];
                    }
                }
            }
            return sum;
        }

        static char[][] convertToGrid(string[] lines)
        {
            List<char[]> rows = new List<char[]>();

            foreach (string line in lines)
            {
                char[] row = line.Trim().ToCharArray();
                rows.Add(row);
            }

            char[][] grid = rows.ToArray();

            return grid;
        }

        static bool checkForSymbols(char[][] grid, int row, int col)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            for (int i = Math.Max(0, row - 1); i <= Math.Min(rows - 1, row + 1); i++)
            {
                for (int j = Math.Max(0, col - 1); j <= Math.Min(cols - 1, col + 1); j++)
                {
                    if (!char.IsDigit(grid[i][j]) && grid[i][j] != '.')
                    {
                        return true;
                    } 
                }
            }
            return false;
        }

        static int[] checkForNumbers(char[][] grid, int row, int col)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            int[] numbers = new int[2];
            for (int i = Math.Max(0, row - 1); i <= Math.Min(rows - 1, row + 1); i++)
            {
                string currNumber = "";
                for (int j = Math.Max(0, col - 1); j <= Math.Min(cols - 1, col + 1); j++)
                {
                    if (char.IsDigit(grid[i][j]))
                    {
                        currNumber = checkLeft(currNumber, grid, i, j - 1);
                        while (j < grid[i].Length && char.IsDigit(grid[i][j]))
                        {
                            currNumber += grid[i][j];
                            j++;
                        }
                    }
                    if (numbers[0] != 0)
                    {
                        int.TryParse(currNumber, out numbers[1]);
                    }
                    else
                    {
                        int.TryParse(currNumber, out numbers[0]);
                    }
                }
            }
            return numbers;
        }

        static string checkLeft(string currNumber, char[][] grid, int i, int j)
        {
            if (j > -1 && char.IsDigit(grid[i][j]))
            {
                currNumber = checkLeft(currNumber, grid, i, j - 1);
                return currNumber += grid[i][j]; 
            }
            return "";
        }

        // For debugging
        static void printGrid(char[][] grid)
        {
             for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    Console.Write(grid[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
