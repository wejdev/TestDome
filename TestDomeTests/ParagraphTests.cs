using JetBrains.Annotations;
using TestDome;

namespace TestDomeTests;

[TestSubject(typeof(Paragraph))]
public class ParagraphTests
{

    [Theory]
    [InlineData("\"Policy: 112-39-8552 and 111-22-3333 completed\"", "\"Policy: 112/8552/39 and 111/3333/22 completed\"")]
    [InlineData(@"Policy: 112-39-8552 and 111-22-3333 completed
asdfasdf asdffsada", @"Policy: 112/8552/39 and 111/3333/22 completed
asdfasdf asdffsada")]
    [InlineData("Hello, World", "Hello, World")]
    [InlineData("112-39-8552", "112/8552/39")]
    [InlineData("\"Your long-term policy number is 112-39-8552.\"", "\"Your long-term policy number is 112/8552/39.\"")]
    [InlineData("\"Policy: 112-39-8552\"", "\"Policy: 112/8552/39\"")]
    [InlineData("\"112-39-8552 abc\"", "\"112/8552/39 abc\"")]
    [InlineData("\"Policy: 112-39-8552 completed\"", "\"Policy: 112/8552/39 completed\"")]
    public void ChangeFormat_ReturnsExpectedResult(string paragraph, string expected)
    {
        var result = Paragraph.ChangeFormat(paragraph);

        Assert.Equal(expected, result);
    }
}
