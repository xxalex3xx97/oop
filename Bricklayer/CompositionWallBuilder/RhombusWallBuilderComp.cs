namespace Bricklayer;

internal class RhombusWallBuilderComp : ICanDefineWhenCubicBrickIsNecessary
{
    public bool IsCubicBrickNecessary(int currentColNumber, int currentRowNumber, bool lastCol, bool firstCol)
    {
        return firstCol || lastCol;
    }
}
