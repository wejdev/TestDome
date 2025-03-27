using JetBrains.Annotations;
using TestDome;

namespace TestDomeTests;

[TestSubject(typeof(MathUtils))]
public class MathUtilsTests
{
    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(0, 2, 1)]
    [InlineData(8, 4, 6)]
    [InlineData(2, 1, 1.5)]
    public void Average_ReturnsExpectedResult(int a, int b, double expected)
    {
        var actual = MathUtils.Average(a, b);

        Assert.Equal(expected, actual);
    }
}
