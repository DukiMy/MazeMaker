using System.Drawing;
namespace MazeMaker;

public interface ITile
{
    Color FillColor { get; }
    UInt16 XOrigin { get; }
    UInt16 YOrigin { get; }
    void DrawTiles(TileType walls);
}
