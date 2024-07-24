namespace MazeMaker;

static class Program
{
    static void Main()
    {
        MatrixBuilder matrix = new MatrixBuilder(
            tileSize: (width: 250, height: 250),
            borderWidth: 4,
            columns: 25,
            rows: 25
        );
    }
}
