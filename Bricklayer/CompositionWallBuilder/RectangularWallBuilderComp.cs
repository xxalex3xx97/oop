namespace Bricklayer;

internal class RectangularWallBuilderComp : ICanDefineWhenCubicBrickIsNecessary, IWallBuilder
{
    public IWallBuilderComp _default { get; set; }

    public GreyPattern GreyPattern => _default.GreyPattern;

    public RectangularWallBuilderComp(GreyPattern greyPattern)
    {
        _default = new DefaultWallBuilderComp(greyPattern, IsCubicBrickNecessary);
    }

    public RowBricks[] BuildWall()
    {
        return _default.BuildWall();
    }

    public bool IsCubicBrickNecessary(int currentColNumber, int currentRowNumber, bool lastCol, bool firstCol)
    {
        bool isNextBrickCubic = GreyPattern.IsContainingBrick(currentColNumber + 1, currentRowNumber);
        bool isPreviousBrickCubic = GreyPattern.IsContainingBrick(currentColNumber - 1, currentRowNumber);
        return firstCol || lastCol || isNextBrickCubic || isPreviousBrickCubic;
    }

}
