using JetBrains.Annotations;
using TestDome;

namespace TestDomeTests;

[TestSubject(typeof(Folders))]
public class FoldersTests
{
    [Fact]
    public void FolderNamesTest()
    {
        var xml =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<folder name=\"c\">" +
            "   <folder name=\"program files\">" +
            "       <folder name=\"uninstall information\" />" +
            "   </folder>" +
            "   <folder name=\"users\" />" +
            "</folder>";
        var startingLetter = 'u';

        var actual = Folders.FolderNames(xml, startingLetter);
        string[] expected = ["uninstall information", "users"];

        Assert.Equal(expected, actual);
    }
}
