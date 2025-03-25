using JetBrains.Annotations;
using TestDome;

namespace TestDomeTests;

[TestSubject(typeof(MathExpression))]
public class MathExpressionTests
{
    [Theory]
    [InlineData("123", true)]
    [InlineData("()", true)]
    [InlineData("{[123]sdaf}", true)]
    [InlineData("{[123}sdaf}", false)]
    [InlineData("1)23", false)]
    [InlineData("1)(23", false)]
    [InlineData("[3 + 5 x (4-1] -39]", false)]
    [InlineData("()[]{}", true)]
    [InlineData("([{}])", true)]
    [InlineData("(]", false)]
    [InlineData("([)]", false)]
    [InlineData("(((())))", true)]
    [InlineData("(((()))", false)]
    public void IsBalancedTest(string parenthesis, bool expected)
    {
        // Act
        var actual = MathExpression.IsBalanced(parenthesis);

        // Assert
        Assert.Equal(expected, actual);
    }
}
