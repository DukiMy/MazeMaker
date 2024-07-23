﻿namespace MazeMaker;

static class Program
{
    static void Main()
    {
        MazeBuilder maze = new MazeBuilder(
            tileSize: (width: 25, height: 25),
            borderWidth: 1,
            columns: 15,
            rows: 15
        );
    }
}
