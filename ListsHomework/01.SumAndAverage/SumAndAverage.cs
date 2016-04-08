namespace _01.SumAndAverage
{
    using System;
    using System.Linq;

    public class SumAndAverage
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Sum=0; Average=0");
                return;
            }
            
            var numbers = input.Split(' ').Select(int.Parse).ToList();
            int sum = numbers.Sum();
            double average = numbers.Average();

            Console.WriteLine($"Sum={sum}; Average={average}");
        }
    }
}