using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using static MazeMaker.TileSettings;
namespace MazeMaker;
public class MazeBuilder
{
    private readonly UInt16 _rowMax;
    private readonly UInt16 _colMax;
    private readonly UInt16 _borderWidth;
    private readonly ITile[] _tiles = new ITile[0];
    private readonly (UInt16 width, UInt16 height) _canvasSize;
    private readonly (UInt16 width, UInt16 height) _tileSize;
    private static readonly Random random = new Random();


    public MazeBuilder(
        (UInt16 width, UInt16 height) tileSize,
        UInt16 borderWidth,
        UInt16 columns,
        UInt16 rows
    )
    {
        _tileSize = tileSize;
        _borderWidth = borderWidth;
        _rowMax = rows;
        _colMax = columns;
        _canvasSize = CalculateCanvasSize();
        bmp = new Bitmap(_canvasSize.width, _canvasSize.height);

        TileSettings.Initialize(
            borderColor: Color.Black,
            width: _tileSize.width,
            height: _tileSize.height,
            borderWidth: _borderWidth
        );

        for (int col = 0; col <= _colMax; col++)
        {
            for (int row = 0; row < _rowMax; row++)
            {
                new WestSouthTile(
                    fillColor: ColorTranslator.FromHtml("#353532"),
                    xOrigin: (UInt16)((_tileSize.width - BorderWidth)*col),
                    yOrigin: (UInt16)((_tileSize.height - BorderWidth)*row),
                    walls: GetRandomEnumValue<OpenWall>()
                );
            }
        }

        DateTime date = DateTime.Now;
        // Get the parent directory of the current directory
        string parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory())!.FullName;
        string directoryPath = Path.Combine(parentDirectory, "Mazes", date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
        string filePath = Path.Combine(directoryPath, $"maze_{date.ToString("HH_mm_ss_fff", CultureInfo.InvariantCulture)}.png");

        try
        {
            // Ensure the directory exists
            Directory.CreateDirectory(directoryPath);

            // Save the bitmap with the generated file path
            bmp.Save(filePath, ImageFormat.Png);

            Console.WriteLine($"Image saved to: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to save the image. Exception: {ex.Message}");
        }
    }
    public static T GetRandomEnumValue<T>() where T : Enum
    {
        Array values = Enum.GetValues(typeof(T));
            T randomValue = (T)values.GetValue(random.Next(values.Length))!;
        return randomValue;
    }

    public static string GetRandomHexColor()
    {
        Random random = new Random();
        int colorValue = random.Next(0x1000000); 
        return $"#{colorValue:X6}";
    }
    
    private (UInt16, UInt16) CalculateCanvasSize()
    {

        Console.WriteLine($"\n\nCanvas size: {(UInt16)((_tileSize.width - _borderWidth)*_colMax)}x{(UInt16)((_tileSize.height - BorderWidth)*_rowMax)}\n\n");
        return (
            (UInt16)((_tileSize.width - _borderWidth)*_colMax),
            (UInt16)((_tileSize.height - _borderWidth)*_rowMax)
        );
    }
}
