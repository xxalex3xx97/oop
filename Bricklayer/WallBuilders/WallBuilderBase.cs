namespace Bricklayer;

internal abstract class WallBuilderBase : IWallBuilder
{
    protected readonly GreyPattern GreyPattern;

    protected WallBuilderBase(GreyPattern greyPattern)
    {
        GreyPattern = greyPattern;
    }

    private Brick cubicRedBrick = new Brick
    {
        Width = 10,
        Height = 10,
        Depth = 10,
        Color = Color.Red
    };

    private Brick parallelepipedRedBrick = new Brick
    {
        Width = 20,
        Height = 10,
        Depth = 10,
        Color = Color.Red
    };

    private Brick parallelepipedGreyBrick = new Brick
    {
        Width = 20,
        Height = 10,
        Depth = 10,
        Color = Color.Grey
    };
    private int TotalWidth { get; } = 180;
    private int TotalHeight { get; } = 90;

    public virtual RowBricks[] BuildWall()
    {
        RowBricks[] wall = new RowBricks[1];

        int builtHeight = 0;
        int currentRowNumber = 1;

        // built the wall
        while (builtHeight < TotalHeight)
        {
            var currentRow = NewBricksRow(currentRowNumber);

            wall[currentRowNumber - 1] = new RowBricks
            {
                RowNumber = currentRowNumber,
                Bricks = currentRow
            };

            currentRowNumber++;
            builtHeight += currentRow[0].Height;
            if (builtHeight < TotalHeight)
            {
                Array.Resize<RowBricks>(ref wall, currentRowNumber);
            }
        }

        return wall;
    }

    protected virtual Brick[] NewBricksRow(int currentRowNumber)
    {
        Brick[] currentRow = new Brick[1];

        int builtWidth = 0;
        int currentColNumber = 1;

        Brick currentBrick = parallelepipedRedBrick;
        while (builtWidth < TotalWidth)
        {
            bool lastBrickOfTheRow = builtWidth + currentBrick.Width >= TotalWidth;

            currentBrick = PlaceBrickInRow(currentColNumber, currentRowNumber, lastBrickOfTheRow);
            currentRow[currentColNumber - 1] = currentBrick;

            builtWidth += currentBrick.Width;
            currentColNumber++;
            if (!lastBrickOfTheRow)
            {
                Array.Resize<Brick>(ref currentRow, currentColNumber);
            }
        }
        return currentRow;
    }

    protected virtual Brick PlaceBrickInRow(int currentColNumber, int currentRowNumber, bool lastCol)
    {
        Brick currentBrick = parallelepipedRedBrick;
        if (GreyPattern.IsContainingBrick(currentColNumber, currentRowNumber))
        {
            currentBrick = parallelepipedGreyBrick;
        }

        bool evenRow = currentRowNumber % 2 == 0;
        bool firstCol = currentColNumber == 1;
        currentBrick = PlaceCubicBrickWhenNecessary(currentColNumber, currentRowNumber, lastCol, currentBrick, evenRow, firstCol);

        return currentBrick;
    }

    protected virtual Brick PlaceCubicBrickWhenNecessary(int currentColNumber, int currentRowNumber, bool lastCol, Brick currentBrick, bool evenRow, bool firstCol)
    {
        if (evenRow)
        {
            if (IsCubicBrickNecessary(currentColNumber, currentRowNumber, lastCol, firstCol))
            {
                currentBrick = cubicRedBrick;
            }
        }

        return currentBrick;
    }

    protected abstract bool IsCubicBrickNecessary(int currentColNumber, int currentRowNumber, bool lastCol, bool firstCol);

}
