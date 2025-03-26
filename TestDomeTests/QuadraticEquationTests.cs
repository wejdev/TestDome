using JetBrains.Annotations;
using TestDome;

namespace TestDomeTests;

[TestSubject(typeof(QuadraticEquation))]
public class QuadraticEquationTests
{
    [Theory]
    [InlineData(2, 10, 8, -1, -4)]
    [InlineData(1, -2, 1, 1, 1)] // perfect square: one root
    [InlineData(1, 0, -4, 2, -2)] // x² - 4 = 0 → ±2
    public void FindRootsTest(double a, double b, double c, double expected1, double expected2)
    {
        var expected = (expected1, expected2);

        var result = QuadraticEquation.FindRoots(a, b, c);
        var actual = (result.Item1, result.Item2);

        AssertTupleEqualsEitherOrder(expected, actual);
    }

    void AssertTupleEqualsEitherOrder((double, double) expected, (double, double) actual, double tolerance = 1e-6)
    {
        bool Match(double a, double b) => Math.Abs(a - b) < tolerance;

        bool matches =
            (Match(actual.Item1, expected.Item1) && Match(actual.Item2, expected.Item2)) ||
            (Match(actual.Item1, expected.Item2) && Match(actual.Item2, expected.Item1));

        Assert.True(matches,
            $"Expected ({expected.Item1}, {expected.Item2}), but got ({actual.Item1}, {actual.Item2})");
    }
}
