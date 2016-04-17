using System;

public class CircularQueue<T>
{
    private const int InitialCapacity = 16;

    private T[] items;
    private int startIndex = 0;
    private int endIndex = 0;

    public int Count { get; private set; }

    public CircularQueue()
    {
        this.items = new T[InitialCapacity];
    }

    public CircularQueue(int capacity)
    {
        this.items = new T[capacity];
    }

    public void Enqueue(T element)
    {
        if (this.Count >= this.items.Length)
        {
            this.Grow();
        }

        this.items[this.endIndex] = element;
        this.endIndex = (this.endIndex + 1) % this.items.Length;
        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Empty queue");
        }

        var dequeuedItem = this.items[this.startIndex];
        this.items[this.startIndex] = default(T);
        this.startIndex = (this.startIndex + 1) % this.items.Length;

        this.Count--;
        return dequeuedItem;
    }

    public T[] ToArray()
    {
        var resultArray = new T[this.Count];
        this.CopyAllItemsTo(resultArray);

        return resultArray;
    }

    private void Grow()
    {
        var newItems = new T[2 * this.items.Length];
        this.CopyAllItemsTo(newItems);
        this.items = newItems;

        this.startIndex = 0;
        this.endIndex = this.Count;
    }

    private void CopyAllItemsTo(T[] newItems)
    {
        int sourceIndex = this.startIndex;
        int destinationIndex = 0;
        for (int i = 0; i < this.Count; i++)
        {
            newItems[destinationIndex] = this.items[sourceIndex];

            sourceIndex = (sourceIndex + 1) % this.items.Length;
            destinationIndex++;
        }
    }
}


class Example
{
    static void Main()
    {
        var queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        var first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
