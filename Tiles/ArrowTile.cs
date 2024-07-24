using System;
using System.Drawing;
using static MazeMaker.TileSettings;
namespace MazeMaker;

public struct ArrowTile : ITile
{
    public Color FillColor => _fillColor;
    public UInt16 XOrigin => _xOrigin;
    public UInt16 YOrigin => _yOrigin;

    private readonly Color _fillColor;
    private readonly UInt16 _xOrigin;
    private readonly UInt16 _yOrigin;
    private readonly SolidBrush _brush;
    private readonly Pen _pen;

    public ArrowTile(
        Color fillColor,
        UInt16 xOrigin,
        UInt16 yOrigin,
        TileType walls
    )
    {
        _fillColor = fillColor;
        _brush = new SolidBrush(fillColor);
        _pen = new Pen(Color.Red, BorderWidth);
        _xOrigin = xOrigin;
        _yOrigin = yOrigin;
        Draw();
        DrawWalls(walls);
    }

    public void DrawWalls(TileType wallMask)
    {
        if ((wallMask & TileType.North) != 0)
        {
            UpArrow();
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
    private void UpArrow()
    {
        float x0 = _xOrigin + Width / 2;
        float y0 = _yOrigin + Height - Height / 6;
        
        float x1 = _xOrigin + Width / 2;
        float y1 = _yOrigin + Height / 6;

        float x2 = _xOrigin + Width / 6;
        float y2 = _yOrigin + Height / 2;

        float x3 = _xOrigin + Width - (Width / 6);
        float y3 = _yOrigin + Height / 2;

        float x4 = _xOrigin + Width / 2;
        float y4 = _yOrigin + Height / 6;

        PointF[] points = new PointF[]
        {
            new PointF(x0, y0),
            new PointF(x1, y1),
            new PointF(x2, y2),
            new PointF(x3, y3),
            new PointF(x4, y4),
        };

        g!.DrawLines(
            pen: _pen,
            points: points
        );
    }

    private void CoolRocketArrows()
    {
        float x0 = _xOrigin + Width / 2;
        float y0 = _yOrigin + Height - Height / 6;
        
        float x1 = _xOrigin + Width / 2;
        float y1 = Height / 6;

        float x2 = _xOrigin + Width / 6;
        float y2 = _yOrigin + Height / 2;

        float x3 = _xOrigin + Width - (Width / 6);
        float y3 = _yOrigin + Height / 2;

        float x4 = _xOrigin + Width / 2;
        float y4 = Height / 6;

        PointF[] points = new PointF[]
        {
            new PointF(x0, y0),
            new PointF(x1, y1),
            new PointF(x2, y2),
            new PointF(x3, y3),
            new PointF(x4, y4),
        };

        g!.DrawLines(
            pen: _pen,
            points: points
        );
    }

    private void OpenEastWall()
    {
        // g!.FillRectangle(
        //     brush:  _brush,
        //     x:      _xOrigin + Width - BorderWidth,
        //     y:      _yOrigin + BorderWidth,
        //     width:  BorderWidth,
        //     height: Height - BorderWidth * 2
        // );
    }

    private void OpenSouthWall()
    {
        // g!.FillRectangle(
        //     brush: _brush,
        //     x:     _xOrigin + BorderWidth,
        //     y:     _yOrigin + Height - BorderWidth,
        //     width:  Width - BorderWidth * 2,
        //     height: BorderWidth
        // );
    }

    private void OpenWestWall()
    {
        // g!.FillRectangle(
        //     brush:  _brush,
        //     x:      _xOrigin,
        //     y:      _yOrigin + BorderWidth,
        //     width:  BorderWidth,
        //     height: Height - BorderWidth * 2
        // );
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
