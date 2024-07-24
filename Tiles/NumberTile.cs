using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using static MazeMaker.TileSettings;

namespace MazeMaker;

public struct NumberTile : ITile
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

    public NumberTile(
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
        DrawNumber();
    }

    private void DrawNumber()
    {
        Font font = new Font("Consolas", 15, FontStyle.Bold);
        Brush brush = new SolidBrush(Color.Black);
        PointF point = new PointF(_xOrigin + 5, _yOrigin + 5);

        g.DrawString(NumberTileSign.ToString(), font, brush, point);
        NumberTileSign++;
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