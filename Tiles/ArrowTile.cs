using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
    private readonly SolidBrush _symbolBrush;

    public ArrowTile(
        Color fillColor,
        UInt16 xOrigin,
        UInt16 yOrigin,
        TileType tileMask
    )
    {
        _fillColor = fillColor;
        _xOrigin = xOrigin;
        _yOrigin = yOrigin;
        _brush = new SolidBrush(fillColor);
        _pen = new Pen(Color.Red, BorderWidth);
        _symbolBrush = new SolidBrush(Color.White);
        DrawFloor();
        DrawTiles(tileMask);
    }

    public void DrawTiles(TileType tileMask)
    {
        if ((tileMask & TileType.North) != 0)
        {
            NorthArrow();
        }
        if ((tileMask & TileType.East) != 0)
        {
            EastArrow();
        }
        if ((tileMask & TileType.South) != 0)
        {
            SouthArrow();
        }
        if ((tileMask & TileType.West) != 0)
        {
            WestArrow();
        }
    }
    private void NorthArrow()
    {   
        // Arrow bow point
        float x0 = _xOrigin + TileSize.width / 2;
        float y0 = _yOrigin + TileSize.height / 6;

        // Arrow port point
        float x1 = _xOrigin + TileSize.width / 6;
        float y1 = _yOrigin + TileSize.height / 2;

        // Arrow starboard point
        float x2 = _xOrigin + TileSize.width - (TileSize.width / 6);
        float y2 = _yOrigin + TileSize.height / 2;

        PointF[] points = new PointF[]
        {
            new PointF(x0, y0),
            new PointF(x1, y1),
            new PointF(x2, y2),
            new PointF(x0, y0)
        };


        DrawSymbol(points);
    }

    private void EastArrow()
    {
        // Arrow bow point
        float x0 = _xOrigin + TileSize.width - (TileSize.width / 6);
        float y0 = _yOrigin + TileSize.height / 2;

        // Arrow port point
        float x1 = _xOrigin + TileSize.width / 2;
        float y1 = _yOrigin + TileSize.height - (TileSize.height / 6);

        // Arrow starboard point
        float x2 = _xOrigin + TileSize.width / 2;
        float y2 = _yOrigin + TileSize.height / 6;

        PointF[] points = new PointF[]
        {
            new PointF(x0, y0),
            new PointF(x1, y1),
            new PointF(x2, y2),
            new PointF(x0, y0)
        };


        DrawSymbol(points);
    }

    private void SouthArrow()
    {   
        // Arrow bow point
        float x0 = _xOrigin + TileSize.width / 2;
        float y0 = _yOrigin + TileSize.height - (TileSize.height / 6);

        // Arrow port point
        float x1 = _xOrigin + TileSize.width / 6;
        float y1 = _yOrigin + TileSize.height / 2;

        // Arrow starboard point
        float x2 = _xOrigin + TileSize.width - (TileSize.width / 6);
        float y2 = _yOrigin + TileSize.height / 2;

        PointF[] points = new PointF[]
        {
            new PointF(x0, y0),
            new PointF(x1, y1),
            new PointF(x2, y2),
            new PointF(x0, y0)
        };

        DrawSymbol(points);
    }

    private void WestArrow()
    {   
        // Arrow bow point
        float x0 = _xOrigin + TileSize.width / 6;
        float y0 = _yOrigin + TileSize.height / 2;

        // Arrow port point
        float x1 = _xOrigin + TileSize.width / 2;
        float y1 = _yOrigin + TileSize.height - (TileSize.height / 6);

        // Arrow starboard point
        float x2 = _xOrigin + TileSize.width / 2;
        float y2 = _yOrigin + TileSize.height / 6;

        PointF[] points = new PointF[]
        {
            new PointF(x0, y0),
            new PointF(x1, y1),
            new PointF(x2, y2),
            new PointF(x0, y0)
        };

        DrawSymbol(points);
    }

    private void CoolRocketArrows()
    {
        float x0 = _xOrigin + TileSize.width / 2;
        float y0 = _yOrigin + TileSize.height - TileSize.height / 6;
        
        float x1 = _xOrigin + TileSize.width / 2;
        float y1 = TileSize.height / 6;

        float x2 = _xOrigin + TileSize.width / 6;
        float y2 = _yOrigin + TileSize.height / 2;

        float x3 = _xOrigin + TileSize.width - (TileSize.width / 6);
        float y3 = _yOrigin + TileSize.height / 2;

        float x4 = _xOrigin + TileSize.width / 2;
        float y4 = TileSize.height / 6;

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

    private void DrawSymbol(PointF[] points)
    {
        g!.FillPolygon(
            brush: _symbolBrush,
            points: points
        );

        g.DrawPolygon(
            pen: _pen,
            points: points
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
