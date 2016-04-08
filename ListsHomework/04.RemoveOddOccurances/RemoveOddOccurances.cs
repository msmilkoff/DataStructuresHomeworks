namespace _04.RemoveOddOccurances
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RemoveOddOccurances
    {
        public static void Main(string[] args)
        {
            var sequence = Console.ReadLine().Split().Select(int.Parse).ToList();
            var valuesToRemove = new List<int>();

            for (int i = 0; i < sequence.Count; i++)
            {
                int occurances = sequence.Count(t => sequence[i] == t);
                if (occurances % 2 != 0)
                {
                    valuesToRemove.Add(sequence[i]);
                }
            }

            foreach (var value in valuesToRemove)
            {
                sequence.RemoveAll(x => x == value);
            }

            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
