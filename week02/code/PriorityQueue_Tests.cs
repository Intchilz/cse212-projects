using Microsoft.VisualStudio.TestTools.UnitTesting;

// Problem 2 - PriorityQueue Tests
// Test cases are created and documented

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities and dequeue until empty
    // Expected Result: Items come out in descending priority order
    // Defect(s) Found: Original Dequeue method did not correctly return the highest priority
    public void TestPriorityQueue_HighestPriority()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 2);
        queue.Enqueue("B", 5);
        queue.Enqueue("C", 3);

        var result1 = queue.Dequeue();
        var result2 = queue.Dequeue();
        var result3 = queue.Dequeue();

        Assert.AreEqual("B", result1); // highest priority
        Assert.AreEqual("C", result2);
        Assert.AreEqual("A", result3);
    }

    [TestMethod]
    // Scenario: Add items with the same priority and dequeue
    // Expected Result: The first item added with the same priority is returned first
    // Defect(s) Found: Original Dequeue loop did not handle multiple equal priorities correctly
    public void TestPriorityQueue_SamePriority()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("X", 4);
        queue.Enqueue("Y", 4);
        queue.Enqueue("Z", 4);

        var result1 = queue.Dequeue();
        var result2 = queue.Dequeue();
        var result3 = queue.Dequeue();

        Assert.AreEqual("X", result1);
        Assert.AreEqual("Y", result2);
        Assert.AreEqual("Z", result3);
    }

    // Additional tests can be added if needed
}
