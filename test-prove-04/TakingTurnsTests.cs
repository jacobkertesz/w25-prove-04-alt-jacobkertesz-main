using NUnit.Framework;
using prove_04;

public class TakingTurnsTests
{
    [Test]
    public void TestTakingTurns1()
    {
        // TODO Problem 1 - Run test cases and fix the code to match requirements
        // Test 1
        // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3) and
        //           run until the queue is empty
        // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
        var players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 5);
        players.AddPerson("Sue", 3);
        // Console.WriteLine(players);    // This can be un-commented out for debug help
        var results = new List<string>();
        while (players.Length > 0)
        {
            results.Add(players.GetNextPerson());
        }

        Assert.That(results, Is.EqualTo(
            (string[]) ["Bob", "Tim", "Sue", "Bob", "Tim", "Sue", "Tim", "Sue", "Tim", "Tim"]));
        Assert.That(players.Length, Is.EqualTo(0));

        // Defect(s) Found: The names did not alternate but instead repeat with the last person added being first. 
    }

    [Test]
    public void TestTakingTurns2()
    {
        // Test 2
        // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3)
        //           After running 5 times, add George with 3 turns.  Run until the queue is empty.
        // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
        var players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 5);
        players.AddPerson("Sue", 3);

        var results = new List<string>();
        for (int i = 0; i < 5; i++)
        {
            results.Add(players.GetNextPerson());
        }

        players.AddPerson("George", 3);
        while (players.Length > 0)
        {
            results.Add(players.GetNextPerson());
        }

        Assert.That(results, Is.EqualTo(
        new []{
            "Bob", "Tim", "Sue", "Bob", "Tim", "Sue", "Tim",
            "George", "Sue", "Tim", "George", "Tim", "George"
        }));
        Assert.That(players.Length, Is.EqualTo(0));

        // Defect(s) Found: Same as test1, and when George is added, the name also does not alternate but repeats.
    }

    [Test]
    public void TestTakingTurns3()
    {
        // Test 3
        // Scenario: Create a queue with the following people and turns: Bob (2), Tim (Forever), Sue (3)
        //           Run 10 times.
        // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
        var players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 0);
        players.AddPerson("Sue", 3);
        // Console.WriteLine(players);
        var results = new List<string>();
        for (int i = 0; i < 10; i++)
        {
            results.Add(players.GetNextPerson());
        }

        Assert.That(results, Is.EqualTo(
            (string[]) ["Bob", "Tim", "Sue", "Bob", "Tim", "Sue", "Tim", "Sue", "Tim", "Tim"]));

        // Defect(s) Found: Only runs 5 times not 10.
    }

    [Test]
    public void TestTakingTurns4()
    {
        // Test 4
        // Scenario: Try to get the next person from an empty queue
        // Expected Result: Error message should be displayed
        var players = new TakingTurnsQueue();
        try
        {
            players.GetNextPerson();
            Assert.Fail("The code should fail with an exception");
        }
        catch (InvalidOperationException)
        {
            Assert.Pass("You should have had an exception");
        }

        // Defect(s) Found: Neither message appears.
    }
}