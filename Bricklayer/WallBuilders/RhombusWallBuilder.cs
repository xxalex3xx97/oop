namespace Bricklayer;

internal class RhombusWallBuilder : WallBuilderBase, IWallBuilder
{
    public RhombusWallBuilder(GreyPattern greyPattern) : base(greyPattern)
    {
    }

    protected override bool IsCubicBrickNecessary(int currentColNumber, int currentRowNumber, bool lastCol, bool firstCol)
    {
        return firstCol || lastCol;
    }
}
