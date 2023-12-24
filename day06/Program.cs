using System.Numerics;

namespace AdventOfCode2023.Day06
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
            int[] timeArray = Array.Empty<int>();
            int[] distanceArray = Array.Empty<int>();
            int sum = 0;
            foreach (string line in lines)
            {
                string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (words.Length > 1 && words[0] == "Time:")
                {
                    timeArray = words.Skip(1).Select(int.Parse).ToArray();
                }
                else if (words.Length > 1 && words[0] == "Distance:")
                {
                    distanceArray = words.Skip(1).Select(int.Parse).ToArray();
                }
            }

            for (int i = 0; i < timeArray.Length; i++)
            {
                int count = 0;
                for (int j = 1; j < timeArray[i]; j++)
                {
                    if ( j * (timeArray[i] - j) > distanceArray[i])
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    sum = sum == 0 ? 1 * count : sum * count;
                }
            }

            return sum;
        }

        static int PartTwo(string[] lines)
        {
            int[] timeArray = Array.Empty<int>();
            int[] distanceArray = Array.Empty<int>();
            int sum = 0;
            foreach (string line in lines)
            {
                string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (words.Length > 1 && words[0] == "Time:")
                {
                    timeArray = words.Skip(1).Select(int.Parse).ToArray();
                }
                else if (words.Length > 1 && words[0] == "Distance:")
                {
                    distanceArray = words.Skip(1).Select(int.Parse).ToArray();
                }
            }

            string concatenatedTime = string.Join("", timeArray);
            string concatenatedDistance = string.Join("", distanceArray);
            BigInteger combinedTime = BigInteger.Parse(concatenatedTime);
            BigInteger combinedDistance = BigInteger.Parse(concatenatedDistance);
            int count = 0;
            for (int i = 1; i < combinedTime; i++)
            {
                if (i * (combinedTime - i) > combinedDistance)
                {
                    count++;
                }
            }
            return count;
        }
    }
}