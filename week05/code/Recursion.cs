using System.Collections;

public static class Recursion
{
    /// <summary>
    /// Problem 1: Recursive Squares Sum
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case
        if (n <= 0)
            return 0;

        // Recursive case
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: Permutations Choose
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: if the current word reached the desired size
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive case: choose each unused letter
        foreach (char c in letters)
        {
            string remaining = letters.Replace(c.ToString(), ""); // remove the used letter
            PermutationsChoose(results, remaining, size, word + c);
        }
    }

    /// <summary>
    /// Problem 3: Climbing Stairs with Memoization
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Base cases
        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        // Memoization check
        if (remember.ContainsKey(s))
            return remember[s];

        // Recursive + memoized computation
        decimal ways = CountWaysToClimb(s - 1, remember)
                     + CountWaysToClimb(s - 2, remember)
                     + CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// Problem 4: Wildcard Binary Patterns
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Base case: empty pattern
        if (pattern.Length == 0)
        {
            results.Add("");
            return;
        }

        int index = pattern.IndexOf('*');
        if (index == -1)
        {
            // No wildcards, just add the pattern itself
            results.Add(pattern);
            return;
        }

        // Replace * with 0 and recurse
        string zeroPattern = pattern[..index] + "0" + pattern[(index + 1)..];
        WildcardBinary(zeroPattern, results);

        // Replace * with 1 and recurse
        string onePattern = pattern[..index] + "1" + pattern[(index + 1)..];
        WildcardBinary(onePattern, results);
    }

    /// <summary>
    /// Problem 5: Maze Solver (recursive path finder)
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        // Base: mark current position
        currPath.Add((x, y));

        // If end reached, record path and backtrack
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Explore all directions recursively if valid
        var directions = new (int dx, int dy)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        foreach (var (dx, dy) in directions)
        {
            int newX = x + dx;
            int newY = y + dy;

            if (maze.IsValidMove(newX, newY, currPath))
            {
                SolveMaze(results, maze, newX, newY, new List<(int, int)>(currPath));
            }
        }

        // Backtrack
        currPath.RemoveAt(currPath.Count - 1);
    }
}
