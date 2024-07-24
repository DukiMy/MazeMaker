namespace MazeMaker;
[Flags]
public enum TileType : byte
{
    None =  0,
    North = 0b_0001,
    East =  0b_0010,
    South = 0b_0100,
    West =  0b_1000,
    NorthEast = North | East,
    NorthWest = North | West,
    SouthEast = South | East,
    SouthWest = South | West,
    NorthSouthEast = North | South | East,
    NorthSouthWest = North | South | West,
    NorthSouth = North | South,
    EastWest = East | West,
    All = North | East | South | West
}
