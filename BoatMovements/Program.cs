namespace BoatMovements;

public class BoatMovements
{
    public static bool CanTravelTo(bool[,] gameMatrix, int fromRow, int fromColumn, int toRow, int toColumn)
    {
        var rows = gameMatrix.GetLength(0);
        var cols = gameMatrix.GetLength(1);

        if (
            toRow < 0 || toRow >= rows ||
            toColumn < 0 || toColumn >= cols ||
            fromRow < 0 || fromRow >= rows ||
            fromColumn < 0 || fromColumn >= cols
        )
        {
            return false;
        }

        if (fromRow == toRow)
        {
            var step = fromColumn < toColumn ? 1 : -1;
            for (var col = fromColumn; col != toColumn + step; col += step)
            {
                if (IsLand(gameMatrix, fromRow, col))
                    return false;
            }

            return true;
        }

        if (fromColumn == toColumn)
        {
            var step = fromRow < toRow ? 1 : -1;
            for (var row = fromRow; row != toRow + step; row += step)
            {
                if (IsLand(gameMatrix, row, fromColumn))
                    return false;
            }

            return true;
        }

        return false;
    }

    private static bool IsLand(bool[,] matrix, int row, int col)
    {
        return !matrix[row, col];
    }


    public static void Main()
    {
        bool[,] gameMatrix =
        {
            { false, true, true, false, false, false },
            { true, true, true, false, false, false },
            { true, true, true, true, true, true },
            { false, true, true, false, true, true },
            { false, true, true, true, false, true },
            { false, false, false, false, false, false },
        };

        Console.WriteLine(CanTravelTo(gameMatrix, 3, 2, 2, 2)); // true, Valid move
        Console.WriteLine(CanTravelTo(gameMatrix, 3, 2, 3, 4)); // false, Can't travel through land
        Console.WriteLine(CanTravelTo(gameMatrix, 3, 2, 6, 2)); // false, Out of bounds
    }
}

