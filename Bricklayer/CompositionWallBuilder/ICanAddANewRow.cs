namespace Bricklayer;

internal interface ICanAddANewRow
{
    Brick[] NewBricksRow(int currentRowNumber);
    Brick PlaceBrickInRow(int currentColNumber, int currentRowNumber, bool lastCol);
}
