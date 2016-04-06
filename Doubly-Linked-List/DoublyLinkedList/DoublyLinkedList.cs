namespace Double_Linked_List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private ListNode<T> head;

        private ListNode<T> tail;  

        private class ListNode<T>
        {
            public ListNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }

            public ListNode<T> NextNode { get; set; }

            public ListNode<T> PrevNode { get; set; }
        }

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element);
            }
            else
            {
                var newHead = new ListNode<T>(element);
                newHead.NextNode = this.head;
                this.head.PrevNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element);
            }
            else
            {
                var newTail = new ListNode<T>(element);
                this.tail.NextNode = newTail;
                newTail.PrevNode = this.tail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty");
            }

            var firstElement = this.head.Value;
            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.head = this.head.NextNode;
            }

            this.Count--;
            return firstElement;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Emty list");
            }

            var lastElement = this.tail.Value;
            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.tail.PrevNode.NextNode = null;
            }

            this.Count--;
            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public T[] ToArray()
        {
            var result = new T[this.Count];
            var currentElement = this.head;
            int index = 0;
            while (currentElement != null)
            {
                result[index] = currentElement.Value;
                currentElement = currentElement.NextNode;

                index++;
            }

            return result;
        }
    }
    
    public class Example
    {
        public static void Main()
        {
            var list = new DoublyLinkedList<int>();

            list.ForEach(Console.WriteLine);
            Console.WriteLine("--------------------");

            list.AddLast(5);
            list.AddFirst(3);
            list.AddFirst(2);
            list.AddLast(10);
            Console.WriteLine("Count = {0}", list.Count);

            list.ForEach(Console.WriteLine);
            Console.WriteLine("--------------------");

            list.RemoveFirst();
            list.RemoveLast();
            list.RemoveFirst();

            list.ForEach(Console.WriteLine);
            Console.WriteLine("--------------------");

            list.RemoveLast();

            list.ForEach(Console.WriteLine);
            Console.WriteLine("--------------------");
        }
    }
}