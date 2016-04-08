namespace _06.ImplementReversedList
{
    using System;

    public class Example
    {
        public static void Main(string[] args)
        {
            var list  = new ReversedList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(6);

            Console.WriteLine(list[0]); // 6

            foreach (var i in list)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("\r\n---------------");

            list.Remove(2);
            foreach (var i in list)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("\r\n-----------------");
            list[0] = 10;
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
