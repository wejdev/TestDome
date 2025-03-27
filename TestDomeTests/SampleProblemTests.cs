using JetBrains.Annotations;
using TestDome;

namespace TestDomeTests;

[TestSubject(typeof(SampleProblem))]
public class SampleProblemTests
{
    [Theory]
    [InlineData(1, "1")]
    [InlineData(3, "Fizz")]
    [InlineData(5, "Buzz")]
    [InlineData(15, "FizzBuzz")]
    [InlineData(16, "16")]
    public void FizzBuzz_ReturnsExpectedResult(int input, string expected)
    {
        var result = SampleProblem.FizzBuzz(input);

        Assert.Equal(expected, result);
    }
}
