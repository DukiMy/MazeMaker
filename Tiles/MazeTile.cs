using System;
using System.Drawing;
using static MazeMaker.TileSettings;
namespace MazeMaker;

public struct MazeTile : ITile
{
    public Color FillColor => _fillColor;
    public UInt16 XOrigin => _xOrigin;
    public UInt16 YOrigin => _yOrigin;

    private readonly Color _fillColor;
    private readonly UInt16 _xOrigin;
    private readonly UInt16 _yOrigin;
    private readonly SolidBrush _brush;

    public MazeTile(
        Color fillColor,
        UInt16 xOrigin,
        UInt16 yOrigin,
        TileType walls
    )
    {
        _fillColor = fillColor;
        _brush = new SolidBrush(fillColor);
        _xOrigin = xOrigin;
        _yOrigin = yOrigin;
        Draw();
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
            width:  Width - BorderWidth * 2,
            height: BorderWidth
        );
    }

    private void OpenEastWall()
    {
        g!.FillRectangle(
            brush:  _brush,
            x:      _xOrigin + Width - BorderWidth,
            y:      _yOrigin + BorderWidth,
            width:  BorderWidth,
            height: Height - BorderWidth * 2
        );
    }

    private void OpenSouthWall()
    {
        g!.FillRectangle(
            brush: _brush,
            x:     _xOrigin + BorderWidth,
            y:     _yOrigin + Height - BorderWidth,
            width:  Width - BorderWidth * 2,
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
            height: Height - BorderWidth * 2
        );
    }

    private void Draw()
    {
        Pen pen = new Pen(BorderColor, BorderWidth);

        // Border
        g!.FillRectangle(
            brush:    new SolidBrush(Color.Black),
            x:      _xOrigin,
            y:      _yOrigin,
            width:  Width,
            height: Height
        );

        // Floor
        g.FillRectangle(
            brush:  _brush,
            x:      _xOrigin + BorderWidth,
            y:      _yOrigin + BorderWidth,
            width:  Width - BorderWidth * 2,
            height: Height - BorderWidth * 2
        );
        
        // Forward slash
        // g.DrawLine(
        //     pen:    new Pen(Color.Orange, 1),
        //     x1:     _xOrigin,
        //     y1:     _yOrigin,
        //     x2:     _xOrigin + Width - 1,
        //     y2:     _yOrigin + Height - 1
        // );

        // Backward slash
        // g.DrawLine(
        //     pen:    new Pen(Color.Orange, 1),
        //     x1:     _xOrigin + Width - 1,
        //     y1:     _yOrigin,
        //     x2:     _xOrigin,
        //     y2:     _yOrigin + Height - 1
        // );
    }
}
