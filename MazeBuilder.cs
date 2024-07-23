using System.Drawing;
using System.Drawing.Imaging;
namespace MazeMaker;
public class MazeBuilder
{
    private readonly UInt16 _rowMax;
    private readonly UInt16 _colMax;
    private readonly UInt16 _borderWidth;
    private readonly (UInt16 width, UInt16 height) _tileSize;
    private ITile[,] _maze;

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

        (UInt16 width, UInt16 height) canvasSize = CalculateCanvasSize();
        TileSettings.bmp = new Bitmap(canvasSize.width, canvasSize.height);

        TileSettings.Initialize(
            borderColor: Color.Black,
            width: _tileSize.width,
            height: _tileSize.height,
            borderWidth: _borderWidth
        );

        BuildMaze();
        SaveMaze();
    }

    private void BuildMaze()
    {
        _maze = new ITile[_colMax, _rowMax];

        for (int col = 0; col <= _colMax; col++)
        {
            for (int row = 0; row < _rowMax; row++)
            {
                _maze[col, row] = new MazeTile(
                    fillColor: ColorTranslator.FromHtml("#444444"),
                    xOrigin: (UInt16)((_tileSize.width - _borderWidth)*col),
                    yOrigin: (UInt16)((_tileSize.height - _borderWidth)*row),
                    walls: GetRandomEnumValue<OpenWall>()
                );
            }
        }
    }

    private void SaveMaze()
    {
        DateTime date = DateTime.Now;

        string parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory())!.FullName;
        string directoryPath = Path.Combine(parentDirectory, "Mazes", date.ToString("yyyy-MM-dd"));
        string filePath = Path.Combine(directoryPath, $"maze_{date.ToString("HH_mm_ss_fff")}.png");

        try
        {
            Directory.CreateDirectory(directoryPath);
            TileSettings.bmp!.Save(filePath, ImageFormat.Png);
            Console.WriteLine($"Maze saved to: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to save the maze. Exception: {ex.Message}");
        }
    }

    public static T GetRandomEnumValue<T>() where T : Enum
    {
        Random random = new Random();
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
        UInt16 canvasWidth = (UInt16)((_tileSize.width - _borderWidth)*_colMax);
        UInt16 canvasHeight = (UInt16)((_tileSize.height - _borderWidth)*_rowMax);

        Console.WriteLine($"\n\nCanvas size: {canvasWidth}x{canvasHeight}\n\n");
        
        return (
            canvasWidth,
            canvasHeight
        );
    }
}
