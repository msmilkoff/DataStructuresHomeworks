using System;

namespace ArrayBasedStack
{
    public class ArrayStack<T>
    {
        private const int DefaultCapacity = 16;

        private T[] items;
        private int top;

        public ArrayStack(int capacity = DefaultCapacity)
        {
            this.items = new T[capacity];
        }

        public int Count
        {
            get { return this.top; }
        }

        public int Capacity
        {
            get { return this.items.Length; }
        }

        public void Push(T element)
        {
            if (this.Count >= this.items.Length) 
            {
                this.Grow();
            }

            this.items[this.top] = element;
            this.top++;
        }

        public T Pop()
        {
            var poppedItem = this.items[this.top - 1];
            this.items[this.top - 1] = default(T);

            this.top--;
            return poppedItem;
        }

        public T[] ToArray()
        {
            var result = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                result[i] = this.items[i];
            }

            return result;
        }

        private void Grow()
        {
            T[] newItems = new T[this.items.Length * 2];
            for (int i = 0; i < this.items.Length; i++) 
            {
                newItems[i] = this.items[i];
            }

            this.items = newItems;
        }
    }
}