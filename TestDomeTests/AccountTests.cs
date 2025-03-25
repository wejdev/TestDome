using JetBrains.Annotations;
using Access = Account.Account.Access;

namespace TestDomeTests;

[TestSubject(typeof(Account.Account))]
public class AccountTests
{
    [Fact]
    public void WriterTest()
    {
        Assert.False(Access.Writer.HasFlag(Access.Delete));
        Assert.False(Access.Writer.HasFlag(Access.Publish));
        Assert.True(Access.Writer.HasFlag(Access.Submit));
        Assert.False(Access.Writer.HasFlag(Access.Comment));
        Assert.True(Access.Writer.HasFlag(Access.Modify));
    }

    [Fact]
    public void EditorTest()
    {
        Assert.True(Access.Editor.HasFlag(Access.Delete));
        Assert.True(Access.Editor.HasFlag(Access.Publish));
        Assert.False(Access.Editor.HasFlag(Access.Submit));
        Assert.True(Access.Editor.HasFlag(Access.Comment));
        Assert.False(Access.Editor.HasFlag(Access.Modify));
    }

    [Fact]
    public void OwnerTest()
    {
        Assert.True(Access.Owner.HasFlag(Access.Delete));
        Assert.True(Access.Owner.HasFlag(Access.Publish));
        Assert.True(Access.Owner.HasFlag(Access.Submit));
        Assert.True(Access.Owner.HasFlag(Access.Comment));
        Assert.True(Access.Owner.HasFlag(Access.Modify));
    }
}
