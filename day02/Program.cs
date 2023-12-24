namespace AdventOfCode2023.Day02
{
    class Program
    {
        const int MAX_RED = 12;
        const int MAX_GREEN = 13;
        const int MAX_BLUE = 14;

        static void Main()
        {
            string[] lines = File.ReadAllLines("input.txt");
            Console.WriteLine("Part 1");
            Console.WriteLine(PartOne(lines));

            Console.WriteLine("Part 2");
            Console.WriteLine(PartTwo(lines));
        }

        static int PartOne(string[] lines)
        {
            int sum = 0;
            
            foreach (string line in lines)
            {
                string[] words = line.Split(new char[] { ' ', ',', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
                int i = 0;
                int currGame = 0;
                foreach (string word in words)
                {
                    if (char.IsDigit(word[0]))
                    {
                        if (words[i-1] == "Game")
                        {
                            currGame = int.Parse(words[i].ToString());
                            sum += currGame;
                        }
                        else
                        {
                            int currNum = int.Parse(word);
                            if (words[i+1] == "blue")
                            {
                                if (currNum > MAX_BLUE)
                                {
                                    sum -= currGame;
                                    break;
                                }
                            }
                            else if (words[i+1] == "red")
                            {
                                if (currNum > MAX_RED)
                                {
                                    sum -= currGame;
                                    break;
                                }
                            }
                            else if (words[i+1] == "green")
                            {
                                if (currNum > MAX_GREEN)
                                {
                                    sum -= currGame;
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    i++;
                }   
            }
            return sum;
        }

        static int PartTwo(string[] lines)
        {
            int sum = 0;
            
            foreach (string line in lines)
            {
                string[] words = line.Split(new char[] { ' ', ',', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
                int i = 0;
                int minBlue = 0;
                int minRed = 0;
                int minGreen = 0;
                foreach (string word in words)
                {
                    if (char.IsDigit(word[0]))
                    {
                        int currNum = int.Parse(word);
                        if (words[i+1] == "blue")
                        {
                            if (currNum > minBlue)
                            {
                                minBlue = currNum;
                            }
                        }
                        else if (words[i+1] == "red")
                        {
                            if (currNum > minRed)
                            {
                                minRed = currNum;
                            }
                        }
                        else if (words[i+1] == "green")
                        {
                            if (currNum > minGreen)
                            {
                                minGreen = currNum;
                            }
                        }
                    }
                    i++;
                }
                sum += minBlue * minRed * minGreen;
            }
            return sum;
        }
    }
}
