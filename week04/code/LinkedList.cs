using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

// LinkedList node class
public class LinkedListNode
{
    // Value stored in the node
    public int Value;

    // Reference to the next node (nullable because the last node points to null)
    public LinkedListNode? Next;

    // Constructor
    public LinkedListNode(int value)
    {
        Value = value;
        Next = null;
    }
}

// LinkedList class implementing IEnumerable<int>
public class LinkedList : IEnumerable<int>
{
    // Head and tail references (nullable for empty list)
    private LinkedListNode? _head;
    private LinkedListNode? _tail;

    // Constructor
    public LinkedList()
    {
        _head = null;
        _tail = null;
    }

    // Insert a new node at the head of the list
    public void InsertHead(int value)
    {
        var node = new LinkedListNode(value);
        if (_head == null)
        {
            // Empty list: head and tail both point to new node
            _head = node;
            _tail = node;
        }
        else
        {
            // Link new node to current head and update head
            node.Next = _head;
            _head = node;
        }
    }

    // Insert a new node at the tail of the list
    public void InsertTail(int value)
    {
        var node = new LinkedListNode(value);
        if (_tail == null)
        {
            // Empty list: head and tail both point to new node
            _head = node;
            _tail = node;
        }
        else
        {
            // Link current tail to new node and update tail
            _tail.Next = node;
            _tail = node;
        }
    }

    // Remove the tail node
    public void RemoveTail()
    {
        if (_head == null) return; // Empty list

        if (_head == _tail)
        {
            // Single element: set list to empty
            _head = null;
            _tail = null;
            return;
        }

        // Traverse to the node before the tail
        var current = _head;
        while (current.Next != _tail)
        {
            current = current.Next!;
        }

        current.Next = null;
        _tail = current;
    }

    // Remove the first occurrence of a value
    public void Remove(int value)
    {
        if (_head == null) return; // Empty list

        if (_head.Value == value)
        {
            _head = _head.Next;
            if (_head == null) _tail = null; // List became empty
            return;
        }

        var current = _head;
        while (current.Next != null && current.Next.Value != value)
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            if (current.Next == _tail)
                _tail = current;
            current.Next = current.Next.Next;
        }
    }

    // Insert a new node after the first occurrence of existingValue
    public void InsertAfter(int existingValue, int newValue)
    {
        var current = _head;
        while (current != null && current.Value != existingValue)
        {
            current = current.Next;
        }

        if (current != null)
        {
            var node = new LinkedListNode(newValue);
            node.Next = current.Next;
            current.Next = node;
            if (current == _tail)
                _tail = node; // Update tail if inserted at the end
        }
    }

    // Replace all occurrences of oldValue with newValue
    public void Replace(int oldValue, int newValue)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Value == oldValue)
                current.Value = newValue;
            current = current.Next;
        }
    }

    // Return IEnumerable<int> in reverse order
    public IEnumerable<int> Reverse()
    {
        var stack = new Stack<int>();
        var current = _head;
        while (current != null)
        {
            stack.Push(current.Value);
            current = current.Next;
        }

        while (stack.Count > 0)
            yield return stack.Pop();
    }

    // Convert the linked list to string
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("<LinkedList>{");

        var current = _head;
        while (current != null)
        {
            sb.Append(current.Value);
            if (current.Next != null)
                sb.Append(", ");
            current = current.Next;
        }

        sb.Append("}");
        return sb.ToString();
    }

    // IEnumerable<int> implementation
    public IEnumerator<int> GetEnumerator()
    {
        var current = _head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // Properties for testing
    public LinkedListNode? Head => _head;
    public LinkedListNode? Tail => _tail;
}

// Extension methods for testing
public static class LinkedListExtensions
{
    // Returns true if both head and tail are null
    public static bool HeadAndTailAreNull(this LinkedList ll) => ll.Head == null && ll.Tail == null;

    // Returns true if both head and tail are not null
    public static bool HeadAndTailAreNotNull(this LinkedList ll) => ll.Head != null && ll.Tail != null;

    // Converts IEnumerable<int> to string for tests
    public static string AsString(this IEnumerable<int> list)
    {
        var sb = new StringBuilder();
        sb.Append("<IEnumerable>{");
        bool first = true;
        foreach (var item in list)
        {
            if (!first) sb.Append(", ");
            sb.Append(item);
            first = false;
        }
        sb.Append("}");
        return sb.ToString();
    }
}
