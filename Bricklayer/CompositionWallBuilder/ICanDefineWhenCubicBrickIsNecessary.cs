namespace Bricklayer
{
    internal interface ICanDefineWhenCubicBrickIsNecessary
    {
        bool IsCubicBrickNecessary(int currentColNumber, int currentRowNumber, bool lastCol, bool firstCol);
    }
}