/// <summary>
/// Represents a person in the TakingTurnsQueue.
/// Each person has a name and a number of turns. 
/// A Turns value of 0 or less means the person has infinite turns.
/// </summary>
public class Person
{
    /// <summary>
    /// The name of the person (read-only)
    /// </summary>
    public readonly string Name;

    /// <summary>
    /// Number of turns remaining. 
    /// A value of 0 or less indicates infinite turns.
    /// </summary>
    public int Turns { get; set; }

    /// <summary>
    /// Constructor to create a new person with a name and number of turns
    /// </summary>
    /// <param name="name">Person's name</param>
    /// <param name="turns">Number of turns; 0 or less means infinite turns</param>
    internal Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
    }

    /// <summary>
    /// Returns a string representation of the person
    /// Shows the number of turns remaining, or "Forever" if infinite turns
    /// </summary>
    public override string ToString()
    {
        return Turns <= 0 ? $"({Name}:Forever)" : $"({Name}:{Turns})";
    }
}
