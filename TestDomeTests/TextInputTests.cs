using JetBrains.Annotations;
using UserInput;

namespace TestDomeTests;

[TestSubject(typeof(TextInput))]
public class TextInputTests
{
    [Fact]
    public void TextInputAddTest()
    {
        var input = new TextInput();
        input.Add('1');
        input.Add('a');
        input.Add('0');

        var actual = input.GetValue();
        const string expected = "1a0";

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TextInputGetValueTest()
    {
        const string testStr = "Hello123";
        var input = new TextInput(testStr);

        var actual = input.GetValue();
        const string expected = testStr;

        Assert.Equal(expected, actual);
    }
}
