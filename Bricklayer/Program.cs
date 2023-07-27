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

        GreyPattern rhombusGreyPattern = new GreyPattern(new[] {
            new RowPattern {
                RowNumber = 3,
                ColumnsNumber = new[] { 5 }
            },
            new RowPattern {
                RowNumber = 4,
                ColumnsNumber = new[] { 5,6 }
            },
            new RowPattern {
                RowNumber = 5,
                ColumnsNumber = new[] { 4,6 }
            },
            new RowPattern {
                RowNumber = 6,
                ColumnsNumber = new[] { 5,6 }
            },
            new RowPattern {
                RowNumber = 7,
                ColumnsNumber = new[] { 5 }
            },
        });



        WallBuilder builder = new(rhombusGreyPattern);
        RowBricks[] wall = builder.BuildWall();

        PrintWall printer = new PrintWall(wall);
        printer.Print();


        GreyPattern rectangularGreyPattern = new(new[] {
            new RowPattern {
                RowNumber = 3,
                ColumnsNumber = new[] { 3,4,5,6,7 }
            },
            new RowPattern {
                RowNumber = 4,
                ColumnsNumber = new[] { 4,9 }
            },
            new RowPattern {
                RowNumber = 5,
                ColumnsNumber = new[] { 3,7 }
            },
            new RowPattern {
                RowNumber = 6,
                ColumnsNumber = new[] { 4,9 }
            },
            new RowPattern {
                RowNumber = 7,
                ColumnsNumber = new[] { 3,4,5,6,7 }
            },
        },true);
        WallBuilder builderRectangular = new(rectangularGreyPattern);
        RowBricks[] wallRectangular = builderRectangular.BuildWall();

        PrintWall printerRectangular = new PrintWall(wallRectangular);
        printerRectangular.Print();
        
    }


}
