using System.Drawing;
using static MazeMaker.TileSettings;
namespace MazeMaker;

public class Columnfirst : IStrategy
{
    private readonly UInt16 _rowMax;
    private readonly UInt16 _colMax;

    private TileType[,] _matrix;
    public Columnfirst()
    {
        for (int col = 0; col < _colMax; col++)
        {
            for (int row = 0; row < _rowMax; row++)
            {
                
            }
        }
    }
}