using JetBrains.Annotations;
using TestDome;

namespace TestDomeTests;

[TestSubject(typeof(SortedSearch))]
public class SortedSearchTests
{
    [Theory]
    [InlineData(new[] { 1, 2, 3 }, 10, 3)]
    [InlineData(new[] { 1, 3, 5, 7 }, 4, 2)]
    [InlineData(new int[] { }, 5, 0)]
    [InlineData(new[] { 10, 20, 30 }, 15, 1)]
    public void CountNumbersTest(int[] sortedArray, int lessThan, int expected)
    {
        var actual = SortedSearch.CountNumbers(sortedArray, lessThan);

        Assert.Equal(expected, actual);
    }
}
