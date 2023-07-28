namespace Bricklayer;

internal class RectangularWallBuilder : WallBuilderBase, IWallBuilder
{
    public RectangularWallBuilder(GreyPattern greyPattern) : base(greyPattern)
    {
    }

    protected override bool IsCubicBrickNecessary(int currentColNumber, int currentRowNumber, bool lastCol, bool firstCol)
    {
        bool isNextBrickCubic = GreyPattern.IsContainingBrick(currentColNumber + 1, currentRowNumber);
        bool isPreviousBrickCubic = GreyPattern.IsContainingBrick(currentColNumber - 1, currentRowNumber);
        return firstCol || lastCol || isNextBrickCubic || isPreviousBrickCubic;
    }
}
