using System;
using System.Collections.Generic;

public class Maze
{
    private readonly int[,] grid;
    private readonly int size;

    public Maze(int width, int height, int[] values)
    {
        size = width;
        grid = new int[width, height];
        int index = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                grid[x, y] = values[index++];
            }
        }
    }

    public bool IsEnd(int x, int y)
    {
        return grid[x, y] == 2;
    }

    public bool IsValidMove(int x, int y, List<ValueTuple<int, int>> path)
    {
        if (x < 0 || y < 0 || x >= size || y >= size)
            return false;

        if (grid[x, y] == 0)
            return false;

        if (path.Contains((x, y)))
            return false;

        return true;
    }
}
