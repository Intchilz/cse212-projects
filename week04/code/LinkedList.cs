using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

// LinkedList node class
// Represents a single node in the linked list.
public class LinkedListNode
{
    public int Value;           // Value stored in the node
    public LinkedListNode Next; // Reference to the next node in the list

    // Constructor: initializes the node with a value
    public LinkedListNode(int value)
    {
        Value = value;
        Next = null;
    }
}

// LinkedList class
// Implements a singly linked list of integers with head and tail references
public class LinkedList : IEnumerable<int>
{
    private LinkedListNode _head; // First node in the list
    private LinkedListNode _tail; // Last node in the list

    // Constructor: initializes an empty list
    public LinkedList()
    {
        _head = null;
        _tail = null;
    }

    // Insert at head
    // Adds a new node at the beginning of the list
    public void InsertHead(int value)
    {
        var node = new LinkedListNode(value);
        if (_head == null)
        {
            // Empty list: head and tail point to the new node
            _head = node;
            _tail = node;
        }
        else
        {
            // Non-empty list: new node points to current head
            node.Next = _head;
            _head = node;
        }
    }

    // Insert at tail
    // Adds a new node at the end of the list
    public void InsertTail(int value)
    {
        var node = new LinkedListNode(value);
        if (_tail == null)
        {
            // Empty list: head and tail point to the new node
            _head = node;
            _tail = node;
        }
        else
        {
            // Non-empty list: tail points to new node, update tail
            _tail.Next = node;
            _tail = node;
        }
    }

    // Remove tail
    // Removes the last node from the list
    public void RemoveTail()
    {
        if (_head == null) return; // Empty list

        if (_head == _tail)
        {
            // Only one node: set head and tail to null
            _head = null;
            _tail = null;
            return;
        }

        // Traverse to the second-to-last node
        var current = _head;
        while (current.Next != _tail)
        {
            current = current.Next;
        }
        current.Next = null;
        _tail = current; // Update tail reference
    }

    // Remove first occurrence of value
    // Deletes the first node with the specified value
    public void Remove(int value)
    {
        if (_head == null) return; // Empty list

        if (_head.Value == value)
        {
            _head = _head.Next;
            if (_head == null) _tail = null; // List became empty
            return;
        }

        // Traverse list to find the node before the target
        var current = _head;
        while (current.Next != null && current.Next.Value != value)
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            // Update tail if removing the last node
            if (current.Next == _tail)
                _tail = current;

            // Skip over the node to remove it
            current.Next = current.Next.Next;
        }
    }

    // Insert after first occurrence of existingValue
    // Adds a new node after a node with the specified value
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
                _tail = node; // Update tail if inserted at end
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

    // Reverse enumerable
    // Returns the values of the list in reverse order
    public IEnumerable<int> Reverse()
    {
        var stack = new Stack<int>();
        var current = _head;
        while (current != null)
        {
            stack.Push(current.Value); // Push values onto stack
            current = current.Next;
        }

        while (stack.Count > 0)
            yield return stack.Pop(); // Pop to return in reverse
    }

    // ToString for LinkedList
    // Provides a string representation of the list for debugging/testing
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
    // Allows iteration with foreach
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
    public LinkedListNode Head => _head;
    public LinkedListNode Tail => _tail;
}

// Extension methods for testing
public static class LinkedListExtensions
{
    // Checks if both head and tail are null
    public static bool HeadAndTailAreNull(this LinkedList ll) => ll.Head == null && ll.Tail == null;

    // Checks if both head and tail are not null
    public static bool HeadAndTailAreNotNull(this LinkedList ll) => ll.Head != null && ll.Tail != null;

    // Converts IEnumerable<int> to a string like "<IEnumerable>{...}"
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
