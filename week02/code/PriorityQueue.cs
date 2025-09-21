using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private readonly List<PriorityItem> _queue = new();

    // Add a new value with a priority
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        // Find highest priority index
        int highPriorityIndex = 0;
        for (int i = 1; i < _queue.Count; i++)
        {
            if (_queue[i].Priority >= _queue[highPriorityIndex].Priority)
                highPriorityIndex = i;
        }

        // Remove and return highest priority item
        var item = _queue[highPriorityIndex];
        _queue.RemoveAt(highPriorityIndex);
        return item.Value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}
