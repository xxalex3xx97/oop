namespace Bricklayer
{
    internal class WallBuilderFactory
    {
        private static GreyPattern rhombusGreyPattern = new GreyPattern(new[] {
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

        private static GreyPattern rectangularGreyPattern = new(new[] {
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
        }, true);

        internal static IWallBuilder Create()
        {
            var input = "\0";
            do
            {
                Console.Write(Environment.NewLine);
                if (input != "\0")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Not valid input, please type 1 or 2.");
                    Console.ResetColor();
                }
                Console.Write("Do you want a Rectangular (1) or a Rhombus (2) output? (1/2): ");
                input = Console.ReadLine();
            } while (String.IsNullOrWhiteSpace(input) || (input != "1" && input != "2"));

            if (input.ToLower() == "1")
            {
                return new RectangularWallBuilderComp(rectangularGreyPattern);
            }
            return new DefaultWallBuilderComp(rhombusGreyPattern, new RhombusWallBuilderComp());
        }
    }
}