namespace _02.SortWords
{
    using System;
    using System.Linq;

    public class SortWords
    {
        public static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(' ').ToList();

            var orderedWords = words.OrderBy(w => w);
            Console.WriteLine(string.Join(" ", orderedWords));
        }
    }
}
