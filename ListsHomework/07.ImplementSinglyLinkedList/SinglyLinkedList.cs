namespace _07.ImplementSinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        private class ListNode<T>
        {
            public T Value { get; }

            public ListNode<T> NextNode { get; set; }

            public ListNode(T value)
            {
                this.Value = value;
            } 
        }

        private ListNode<T> head;

        private ListNode<T> currentNode; 

        private int currentIndex;

        public T First => this.head.Value;

        public int Count => this.currentIndex;

        public void Add(T item)
        {
            if (this.Count == 0)
            {
                this.head = this.currentNode = new ListNode<T>(item);
            }
            else
            {
                var newNode = new ListNode<T>(item);
                this.currentNode.NextNode = newNode;
                this.currentNode = newNode;
            }
            
            this.currentIndex++;
        }

        public T Remove(int index)
        {
            T itemToRemove = default(T);

            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Given index does not exist!");
            }

            if (index == 0)
            {
                itemToRemove = this.head.Value;
                this.head = this.head.NextNode;
            }
            else
            {
                var node = this.head;
                for (int i = 1; i < index; i++)
                {
                    node = node.NextNode;
                }

                var previous = node;
                node = node.NextNode;
                itemToRemove = node.Value;
                var next = node.NextNode;
                previous.NextNode = next;
            }

            this.currentIndex--;
            return itemToRemove;
        }

        public int FirstIndexOf(T item)
        {
            int firstIndex = 0;
            foreach (var element in this)
            {
                if (item.Equals(element))
                {
                    return firstIndex;
                }

                firstIndex++;
            }

            return -1;
        }

        public int LastIndexOf(T item)
        {
            var node = this.head;
            for (int i = this.Count - 1; i >= 0; i--)
            {
                var element = node.Value;
                if (element.Equals(item))
                {
                    return i;
                }

                node = node.NextNode;
            }

            return -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;
            while (current != null)
            {
                yield return current.Value;
                current = current.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}