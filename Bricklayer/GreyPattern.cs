namespace Bricklayer;

internal class GreyPattern
{
    public bool IsRectangular { get; }
    internal RowPattern[] Pattern { get; set; }

    public GreyPattern(RowPattern[] pattern, bool isRectangular = false)
    {
        Pattern = pattern;
        IsRectangular = isRectangular;
    }

    public bool IsContainingBrick(int currentColNumber, int currentRowNumber)
    {
        foreach (var greyRow in Pattern)
        {
            if (greyRow.RowNumber != currentRowNumber) { continue; }
            foreach (var greyCol in greyRow.ColumnsNumber)
            {
                if (greyCol != currentColNumber) { continue; }
                return true;
            }
        }
        return false;
    }
}
