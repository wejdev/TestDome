using JetBrains.Annotations;
using TestDome;

namespace TestDomeTests;

[TestSubject(typeof(TwoSum))]
public class TwoSumTests
{
    [Theory]
    [InlineData(new[] { 3, 1, 5, 7, 5, 9 }, 10)]
    [InlineData(new[] { 2, 4, 6, 8 }, 14)]
    [InlineData(new[] { 2, 7, 11, 15 }, 9)]
    [InlineData(new[] { 3, 2, 4 }, 6)]
    [InlineData(new[] { 3, 3 }, 6)]
    public void FindTwoSum_FindsValidPair(int[] numbers, int target)
    {
        // Arrange
        var list = numbers.ToList();

        // Act
        var result = TwoSum.FindTwoSum(list, target);
        var actual = list[result.Item1] + list[result.Item2];

        // Assert
        Assert.NotNull(result);
        Assert.Equal(target, actual);
        Assert.NotEqual(result.Item1, result.Item2);
    }

    [Fact]
    public void FindTwoSum_ReturnsNull_WhenNoPairExists()
    {
        // Arrange
        var numbers = new List<int> { 1, 2, 3 };
        const int target = 100;

        // Act
        var result = TwoSum.FindTwoSum(numbers, target);

        // Assert
        Assert.Null(result);
    }
}
