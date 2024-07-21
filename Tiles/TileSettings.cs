using System.Drawing;
namespace MazeMaker;

public static class TileSettings
{
    public static Bitmap? bmp { get; set; }
    public static Graphics? g { get; private set; }
    public static Color BorderColor { get; private set; }
    public static UInt16 Width { get; private set; }
    public static UInt16 Height { get; private set; }
    public static UInt16 BorderWidth { get; private set; }

    public static void Initialize(
        Color borderColor,
        UInt16 width,
        UInt16 height,
        UInt16 borderWidth
    )
    {
        g = Graphics.FromImage(bmp!);
        g.Clear(ColorTranslator.FromHtml("#323232"));
        BorderColor = borderColor;
        Width = width;
        Height = height;
        BorderWidth = borderWidth;
    }
}
