namespace AdventOfCode2023.Day04
{
    class Program
    {
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
                // Split the line into two parts using "|"
                var parts = line.Split('|');

                // Extract numbers after "Card X:" in both parts
                var winningNumbers = parts[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                         .Skip(2) // Skip "Card X:"
                                         .Select(int.Parse)
                                         .ToArray();

                var matchingNumbers = parts[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray();

                int count = 0;
                double points = 0;
                foreach (int num in matchingNumbers)
                {
                    if (winningNumbers.Contains(num))
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    count--;
                    points = Math.Pow(2, count);
                }
                sum += (int)points;
            }
            return sum;
        }

        static int PartTwo(string[] lines)
        {
            return 0;
        }
    }
}