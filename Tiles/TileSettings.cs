using System.Drawing;
namespace MazeMaker;

public static class TileSettings
{
    public static Bitmap? bmp { get; set; }
    public static Graphics? g { get; private set; }
    public static Color BaseColor { get; set; }
    public static Color BorderColor { get; private set; }
    public static (UInt16 width, UInt16 height) TileSize { get; set; }
    public static UInt16 BorderWidth { get; private set; }
    public static UInt128 NumberTileSign { get; set; }

    public static void Initialize(
        Color baseColor,
        Color borderColor,
        (UInt16 width, UInt16 height) tileSize,
        UInt16 borderWidth
    )
    {
        BaseColor = baseColor;
        BorderColor = borderColor;
        TileSize = tileSize;
        BorderWidth = borderWidth;
        g = Graphics.FromImage(bmp!);
        g.Clear(baseColor);
    }
}
