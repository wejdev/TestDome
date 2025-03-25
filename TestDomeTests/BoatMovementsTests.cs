using JetBrains.Annotations;
using TestDome;

namespace TestDomeTests;

[TestSubject(typeof(BoatMovements))]
public class BoatMovementsTests
{
    private static readonly bool[,] gameMatrix =
    {
        { false, true, true, false, false, false },
        { true, true, true, false, false, false },
        { true, true, true, true, true, true },
        { false, true, true, false, true, true },
        { false, true, true, true, false, true },
        { false, false, false, false, false, false }
    };

    private static readonly bool[,] minimalMatrix =
    {
        { true, true, true },
        { true, true, true },
        { true, true, true }
    };

    private static readonly bool[,] secondMatrix =
    {
        { false, false, true, true, false },
        { false, false, true, false, false },
        { false, false, true, true, false },
        { false, true, false, true, false },
        { false, false, true, false, false }
    };

    private static readonly bool[,] oneByOneMatrix =
    {
        { true }
    };

    private static readonly bool[,] emptyMatrix =
    {
        { }
    };

    public static IEnumerable<object[]> TravelTestData =>
        new List<object[]>
        {
            new object[] { gameMatrix, 3, 2, 2, 2, true },
            new object[] { gameMatrix, 3, 2, 3, 4, false },
            new object[] { gameMatrix, 3, 2, 6, 2, false },
            new object[] { gameMatrix, 0, 0, 0, 1, false },
            new object[] { gameMatrix, 0, 1, 0, 2, true },
            new object[] { gameMatrix, 0, 1, 0, 5, false },
            new object[] { gameMatrix, 0, 1, 4, 1, true },
            new object[] { gameMatrix, 0, 1, 5, 1, false },
            new object[] { gameMatrix, 2, 0, 2, 5, true },
            new object[] { gameMatrix, 3, 5, 3, 3, false },
            new object[] { gameMatrix, 1, 1, 2, 2, false },

            new object[] { minimalMatrix, 0, 0, 0, 2, true },
            new object[] { minimalMatrix, 0, 0, 2, 0, true },
            new object[] { minimalMatrix, 0, 0, 2, 2, false },
            new object[] { minimalMatrix, -1, 0, 0, 0, false },
            new object[] { minimalMatrix, 0, -1, 0, 0, false },
            new object[] { minimalMatrix, 0, 0, -1, 0, false },
            new object[] { minimalMatrix, 0, 0, 0, -1, false },
            new object[] { minimalMatrix, 3, 0, 0, 0, false },
            new object[] { minimalMatrix, 0, 3, 0, 0, false },
            new object[] { minimalMatrix, 0, 0, 3, 0, false },
            new object[] { minimalMatrix, 0, 0, 0, 3, false },
            new object[] { minimalMatrix, 1, 1, 1, 1, true },
            new object[] { minimalMatrix, 1, 1, 2, 2, false },

            new object[] { secondMatrix, 2, 2, 0, 2, true },
            new object[] { secondMatrix, 2, 2, 2, 1, false },
            new object[] { secondMatrix, 2, 2, 2, 3, true },
            new object[] { secondMatrix, 2, 2, 4, 2, false },

            new object[] { oneByOneMatrix, 0, 0, 0, 0, true },
            new object[] { oneByOneMatrix, 0, 0, 1, 1, false },

            new object[] { emptyMatrix, 0, 0, 0, 0, false }
        };

    [Theory]
    [MemberData(nameof(TravelTestData))]
    public void CanTravelToTest(bool[,] matrix, int fromRow, int fromColumn, int toRow, int toColumn, bool expected)
    {
        // Act
        var actual = BoatMovements.CanTravelTo(matrix, fromRow, fromColumn, toRow, toColumn);

        // Assert
        Assert.Equal(expected, actual);
    }
}
