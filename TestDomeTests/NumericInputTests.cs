using JetBrains.Annotations;
using UserInput;

namespace TestDomeTests;

[TestSubject(typeof(NumericInput))]
public class NumericInputTests
{
    [Fact]
    public void NumericInputAddTest()
    {
        TextInput input = new NumericInput();
        input.Add('1');
        input.Add('a');
        input.Add('0');

        var actual = input.GetValue();
        const string expected = "10";

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void NumericInputGetValueTest()
    {
        const string testStr = "123";
        var input = new NumericInput(testStr);

        var actual = input.GetValue();
        const string expected = testStr;

        Assert.Equal(expected, actual);
    }
}
