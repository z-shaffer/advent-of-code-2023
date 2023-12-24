namespace AdventOfCode2023.Day07
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
            List<string> handList = new List<string>();
            List<int> bidList = new List<int>();

            foreach (string line in lines)
            {
                string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                handList.Add(words[0]);
                bidList.Add(int.Parse(words[1]));
            }


            return sum;
        }

        static int PartTwo(string[] lines)
        {
            return 0;
        }
    }
}