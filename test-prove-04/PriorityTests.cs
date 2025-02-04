using NUnit.Framework;
using prove_04;

public class PriorityTests
{
    [Test]
    public void TestPriority1()
    {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Test 1
        // Scenario: The Enqueue function shall add an item (which contains both data and priority) to the back of the queue
        // Expected Result: "[Name 1 (Pri:1), Name 2 (Pri:1)]

        var priorityQueue = new PriorityQueue(); // Example of creating and using the priority queue
        //Console.WriteLine(priorityQueue);
        priorityQueue.Enqueue("Name 1", 1);
        priorityQueue.Enqueue("Name 2", 1);
        Assert.That(priorityQueue.ToString(), Is.EqualTo("[Name 1 (Pri:1), Name 2 (Pri:1)]"));
        // Make sure you use Assert.That(<whatever>, Is.EqualTo(<expected value>));

        // Defect(s) Found: 
    }

    [Test]
    public void TestPriority2()
    {
        // Test 2
        // Scenario: The Dequeue function shall remove the item with the highest priority and return its value
        // Expected Result: "Name 2"
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Name 1", 1);
        priorityQueue.Enqueue("Name 2", 2);
        var result = priorityQueue.Dequeue();
        Assert.That(result.ToString(), Is.EqualTo("Name 2"));
        // Make sure you use Assert.That(<whatever>, Is.EqualTo(<expected value>));

        // Defect(s) Found: The method did not respect priority.
    }

    [Test]
    public void TestPriority3()
    {
        // Test 3
        // Scenario: If there are more than one item with the highest priority, then the item closest to the front of the queue will be removed and its value returned
        // Expected Result: "Name 2"
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Name 1", 1);
        priorityQueue.Enqueue("Name 2", 2);
        priorityQueue.Enqueue("Name 3", 1);
        priorityQueue.Enqueue("Name 4", 2);
        var result = priorityQueue.Dequeue();
        Assert.That(result.ToString(), Is.EqualTo("Name 2"));
    }

    [Test]
    public void TestPriority4()
    {
        // Test 4
        // Scenario: If the queue is empty, then an error message will be displayed
        // Expected Result: 
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("The code should fail with an exception");
        }
        catch (InvalidOperationException)
        {
            Assert.Pass("You should have had an exception");
        }
    }
    // TODO Add more test cases as needed to test all of the requirements and find all the bugs
}