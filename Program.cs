namespace MazeMaker;

static class Program
{
    static void Main()
    {
        MatrixBuilder matrix = new MatrixBuilder(
            tileSize: (width: 50, height: 50),
            borderWidth: 1,
            columns: 25,
            rows: 25
        );
    }
}
