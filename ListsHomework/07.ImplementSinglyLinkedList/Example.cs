namespace _07.ImplementSinglyLinkedList
{
    using System;

    public class Example
    {
        public static void Main(string[] args)
        {
            var list = new SinglyLinkedList<string>();

            // Test Count with empty list
            Console.WriteLine("Count = " + list.Count);
            Console.WriteLine("=========");

            // Add
            list.Add("Pesho");
            list.Add("Gosho");
            list.Add("Kiro");
            list.Add("Vlado");
            list.Add("Maria");

            // Test if added correctly and if Count changed
            foreach (var name in list)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("===========");
            Console.WriteLine("Count = " + list.Count);
            Console.WriteLine("==========");

            // Test if correct item was removed and Count was dicreased
            var removed = list.Remove(0);
            Console.WriteLine($"\r\nRemoved => {removed}\r\n");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("==========");
            Console.WriteLine("Count = " + list.Count);
            Console.WriteLine("==========");

            // Test first and last index of
            var nums = new SinglyLinkedList<int> {5, 10, 15, 20, 10, 30};
            Console.WriteLine(nums.FirstIndexOf(10));
            Console.WriteLine(nums.LastIndexOf(10));
        }
    }
}
