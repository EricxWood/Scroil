// WARNING: capacity MUST be the power of 2!!!!!!!!!!!


using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

sealed class RingBuffer<T> : IEnumerable<T>
{
    private readonly T[] buffer;
    private int head = 0;
    private int tail = 0;
    private int count = 0;
    private readonly int capacity;
    private readonly int mask; // For fast wraparound

    public RingBuffer(int capacity)
    {
        if ((capacity & (capacity - 1)) != 0)
            throw new ArgumentException("Capacity must be a power of 2");

        this.capacity = capacity;
        this.mask = capacity - 1;
        buffer = new T[capacity];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Enqueue(T item)
    {
        buffer[tail] = item;
        tail = (tail + 1) & mask;

        if (count == capacity)
        {
            head = (head + 1) & mask; // overwrite oldest
        }
        else
        {
            count++;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Dequeue()
    {
        if (count == 0)
            throw new InvalidOperationException("Ring buffer is empty");

        T item = buffer[head];
        head = (head + 1) & mask;
        count--;
        return item;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ref T GetRef(int index)
    {
        int actualIndex = (head + index) & mask;
        return ref buffer[actualIndex];
    }

    public int Count => count;
    public int Capacity => capacity;

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < count; i++)
        {
            int index = (head + i) & mask;
            yield return buffer[index]; // Copy if T is a struct
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    // Optional Span optimization (fallbacks when wrap-around is complex)
    public Span<T> GetActiveSpan()
    {
        if (head < tail)
            return buffer.AsSpan(head, count);

        // Wrapping: not contiguous — caller must handle manually
        return new Span<T>(buffer); // Not safe to use blindly
    }
}
