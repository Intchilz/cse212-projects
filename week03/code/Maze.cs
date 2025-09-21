using System;
using System.Collections.Generic;

public class Maze
{
    // Dictionary representing the maze
    // Key = (x, y) coordinate, Value = [left, right, up, down] allowed moves
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;

    // Current position in maze (starts at 1,1)
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // Move left if allowed, otherwise throw exception
    public void MoveLeft()
    {
        if (!_mazeMap[(_currX, _currY)][0])
            throw new InvalidOperationException("Can't go that way!");
        _currX--; // update position
    }

    // Move right if allowed, otherwise throw exception
    public void MoveRight()
    {
        if (!_mazeMap[(_currX, _currY)][1])
            throw new InvalidOperationException("Can't go that way!");
        _currX++;
    }

    // Move up if allowed, otherwise throw exception
    public void MoveUp()
    {
        if (!_mazeMap[(_currX, _currY)][2])
            throw new InvalidOperationException("Can't go that way!");
        _currY--;
    }

    // Move down if allowed, otherwise throw exception
    public void MoveDown()
    {
        if (!_mazeMap[(_currX, _currY)][3])
            throw new InvalidOperationException("Can't go that way!");
        _currY++;
    }

    // Returns a string showing current position
    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
