namespace Bricklayer;

enum Color
{
    Red,
    Grey
}

struct Brick
{
    public int Width;
    public int Height;
    public int Depth;
    public Color Color;
}

internal static class Program
{
    private static void Main(string[] args)
    {

        IWallBuilder builder = WallBuilderFactory.Create();
        RowBricks[] wall = builder.BuildWall();

        PrintWall printer = new PrintWall(wall);
        printer.Print();

    }


}
