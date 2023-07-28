namespace Bricklayer;

internal interface ICanPlaceCubicBrickWhenNecessary : ICanDefineWhenCubicBrickIsNecessary
{
    Brick PlaceCubicBrickWhenNecessary(int currentColNumber, int currentRowNumber, bool lastCol, Brick currentBrick, bool evenRow, bool firstCol);
}
