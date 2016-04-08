namespace _03.LongestSubsequence
{
    using System;
    using System.Collections.Generic;

    public class LongestSubsequence
    {
        public static void Main(string[] args)
        {
            var tests = new List<List<int>>
            {
                new List<int> {12, 2, 7, 4, 3, 3, 8},
                new List<int> {2, 2, 2, 3, 3, 3},
                new List<int> {4, 4, 5, 5, 5},
                new List<int> {1, 2, 3},
                new List<int> {0}
            };

            foreach (var test in tests)
            {
                var result = GetLongestSubsequence(test);
                Console.WriteLine(string.Join(" ", result));
                Console.WriteLine("-------------------");
            }

        }

        private static List<int> GetLongestSubsequence(List<int> input)
        {
            if (input.Count == 1)
            {
                return input;
            }

            var currentSeq = new List<int>();
            var longestSeq = new List<int>();

            currentSeq.Add(input[0]);

            for (int i = 1; i < input.Count; i++)
            {
                if (input[i] == input[i - 1])
                {
                    currentSeq.Add(input[i]);
                }
                else
                {
                    UpdateLongestSeq(longestSeq, currentSeq);

                    currentSeq.Clear();
                    currentSeq.Add(input[i]);
                }

                UpdateLongestSeq(longestSeq, currentSeq);
            }

            return longestSeq;
        }

        private static void UpdateLongestSeq(List<int> longestSeq, List<int> currentSeq)
        {
            if (longestSeq.Count < currentSeq.Count)
            {
                longestSeq.Clear();
                longestSeq.AddRange(currentSeq);
            }
        }
    }
}
