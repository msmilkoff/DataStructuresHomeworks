namespace _05.CountOfOccurances
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountOfOccurances
    {
        public static void Main(string[] args)
        {
            var sequence = Console.ReadLine().Split().Select(int.Parse).ToList();

            var valueOccurances = new SortedDictionary<int, int>();
            foreach (var number in sequence)
            {
                if (!valueOccurances.ContainsKey(number))
                {
                    valueOccurances.Add(number, 1);
                }
                else
                {
                    valueOccurances[number]++;
                }
            }

            foreach (var entry in valueOccurances)
            {
                Console.WriteLine($"{entry.Key} -> {entry.Value} times");
            }
        }
    }
}
