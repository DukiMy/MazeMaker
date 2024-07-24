using System;
using System.Drawing;
using static MazeMaker.TileSettings;
namespace MazeMaker;

public struct MazeTile : ITile
{
    public Color FillColor => _fillColor;
    public UInt16 XOrigin => _xOrigin;
    public UInt16 YOrigin => _yOrigin;

    private readonly SolidBrush _brush;
    private readonly Color _fillColor;
    private readonly UInt16 _xOrigin;
    private readonly UInt16 _yOrigin;

    public MazeTile(Color fillColor, UInt16 xOrigin, UInt16 yOrigin, TileType walls)
    {
        _fillColor = fillColor;
        _brush = new SolidBrush(fillColor);
        _xOrigin = xOrigin;
        _yOrigin = yOrigin;

        DrawFloor();
        DrawTiles(walls);
    }

    public void DrawTiles(TileType wallMask)
    {
        if ((wallMask & TileType.North) != 0)
        {
            OpenNorthWall();
        }
        if ((wallMask & TileType.East) != 0)
        {
            OpenEastWall();
        }
        if ((wallMask & TileType.South) != 0)
        {
            OpenSouthWall();
        }
        if ((wallMask & TileType.West) != 0)
        {
            OpenWestWall();
        }
    }

    private void OpenNorthWall()
    {
        g!.FillRectangle(
            brush: _brush,
            x:     _xOrigin + BorderWidth,
            y:     _yOrigin,
            width:  TileSize.width - BorderWidth * 2,
            height: BorderWidth
        );
    }

    private void OpenEastWall()
    {
        g!.FillRectangle(
            brush:  _brush,
            x:      _xOrigin + TileSize.width - BorderWidth,
            y:      _yOrigin + BorderWidth,
            width:  BorderWidth,
            height: TileSize.width - BorderWidth * 2
        );
    }

    private void OpenSouthWall()
    {
        g!.FillRectangle(
            brush: _brush,
            x:     _xOrigin + BorderWidth,
            y:     _yOrigin + TileSize.width - BorderWidth,
            width:  TileSize.width - BorderWidth * 2,
            height: BorderWidth
        );
    }

    private void OpenWestWall()
    {
        g!.FillRectangle(
            brush:  _brush,
            x:      _xOrigin,
            y:      _yOrigin + BorderWidth,
            width:  BorderWidth,
            height: TileSize.width - BorderWidth * 2
        );
    }

    private void DrawFloor()
    {
        Pen pen = new Pen(BorderColor, BorderWidth);

        // Border
        g!.FillRectangle(
            brush:    new SolidBrush(Color.Black),
            x:      _xOrigin,
            y:      _yOrigin,
            width:  TileSize.width,
            height: TileSize.height
        );

        // Floor
        g.FillRectangle(
            brush:  _brush,
            x:      _xOrigin + BorderWidth,
            y:      _yOrigin + BorderWidth,
            width:  TileSize.width - BorderWidth * 2,
            height: TileSize.height - BorderWidth * 2
        );
    }
}
