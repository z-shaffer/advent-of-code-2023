namespace AdventOfCode2023.Day01
{
    class Program
    {
        static void Main()
        {
            string[] lines = File.ReadAllLines("input.txt");

            Console.WriteLine("Part 1");
            PartOne(lines);

            Console.WriteLine("Part 2");
            PartTwo(lines);
        }

        static void PartOne(string[] lines)
        {
            int sum = 0;
            foreach (string line in lines)
            {
                int firstDigit = 0;
                int secondDigit = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    if (char.IsDigit(line[i]))
                    {
                        firstDigit = 10 * int.Parse(line[i].ToString());
                        break;
                    }
                }
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    if (char.IsDigit(line[i]))
                    {
                        secondDigit = int.Parse(line[i].ToString());
                        break;
                    }
                }
                sum += (firstDigit + secondDigit);
            }
            Console.WriteLine(sum);
        }

        static void PartTwo(string[] lines)
        {
            int sum = 0;
            foreach (string line in lines)
            {
                int firstDigit = 0;
                int secondDigit = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    if (char.IsDigit(line[i]))
                    {
                        firstDigit = 10 * int.Parse(line[i].ToString());
                        break;
                    }
                    else
                    {
                        for (int j = 3; j <= 5; j++)
                        {
                            try
                            {
                                string subLine = line.Substring(i, j);
                                if (hasWordNumber(subLine) != 0)
                                {
                                    firstDigit = 10 * hasWordNumber(subLine);
                                    goto firstDone;
                                }
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                break;
                            }
                        }
                    }
                }
                firstDone:
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    if (char.IsDigit(line[i]))
                    {
                        secondDigit = int.Parse(line[i].ToString());
                        break;
                    }
                    else
                    {
                        for (int j = 3; j <= 5; j++)
                        {
                            try
                            {
                                string subLine = line.Substring(i, j);
                                if (hasWordNumber(subLine) != 0)
                                {
                                    secondDigit = hasWordNumber(subLine);
                                    goto secondDone;
                                }
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                break;
                            }
                        }
                    }
                }
                secondDone:
                sum += (firstDigit + secondDigit);
            }
            Console.WriteLine(sum);

            static int hasWordNumber(string subLine)
            {
                switch (subLine)
                {
                    case "one": return 1;
                    case "two": return 2;
                    case "three": return 3;
                    case "four": return 4;
                    case "five": return 5;
                    case "six": return 6;
                    case "seven": return 7;
                    case "eight": return 8;
                    case "nine": return 9;
                    default: return 0;
                }
            }
        }
    }
}
