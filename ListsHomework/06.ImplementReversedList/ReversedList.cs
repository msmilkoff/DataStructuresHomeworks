namespace _06.ImplementReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 16;

        private T[] items;
        private int currentIdex;

        public ReversedList()
        {
            this.items = new T[InitialCapacity];
        }

        public int Count => this.currentIdex;

        public int Capacity => this.items.Length;

        public void Add(T item)
        {
            if (this.Count > this.items.Length)
            {
                this.Resize();
            }

            this.items[this.currentIdex] = item;
            this.currentIdex++;
        }

        public void Remove(int index) // [ 2 4 6 ]
        {
            this.ValidateIdexIsInRange(index);

            T[] newItems = new T[this.items.Length];
            for (int i = 0; i < this.Count - 1 - index; i++)
            {
                newItems[i] = this.items[i];
            }

            int start = this.Count - index;
            for (int i = start; i < this.Count; i++)
            {
                newItems[i - 1] = this.items[i];
            }

            this.items = newItems;
            this.currentIdex--;
        }
        
        public T this[int index]
        {
            get
            {
                this.ValidateIdexIsInRange(index);

                return this.items[this.Count - 1 - index];
            }

            set
            {
                this.ValidateIdexIsInRange(index);

                this.items[this.Count - 1 - index] = value;
            }
        }

        private void Resize()
        {
            int newCapacity = this.items.Length * 2;
            T[] newItems = new T[newCapacity];

            Array.Copy(this.items, newItems, this.items.Length);
            this.items = newItems;
        }
        
        private void ValidateIdexIsInRange(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index is outside the boundaries of the List");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
