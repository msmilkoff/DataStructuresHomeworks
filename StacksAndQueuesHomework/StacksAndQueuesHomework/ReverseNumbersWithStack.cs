using System;
using System.Linq;
using System.Collections.Generic;

namespace _01_StacksAndQueuesHomework
{
    public class ReverseNumbersWithStack
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("(empty)");
                return;
            }

            var numbers = input.Split(' ').Select(int.Parse).ToArray();

            var numStack = new Stack<int>();
            foreach (var number in numbers)
            {
                numStack.Push(number);
            }

            while (numStack.Count > 0)
            {
                Console.WriteLine(numStack.Pop());
            }
        }
    }
}