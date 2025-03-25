using System.Xml;
using System.Xml.Linq;

namespace TestDome;

public class Folders
{
    public static IEnumerable<string> FolderNames(string xml, char startingLetter)
    {
        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xml);

        return xmlDoc
            .GetElementsByTagName("folder")
            .Cast<XmlNode>()
            .Select(n => n.Attributes["name"].Value)
            .Where(s => s.StartsWith(startingLetter.ToString()));
    }

    public static IEnumerable<string> FolderNamesFancy(string xml, char startingLetter)
    {
        var doc = XDocument.Parse(xml);

        return doc
            .Descendants("folder")
            .Select(e => (string?)e.Attribute("name"))
            .Where(name => !string.IsNullOrEmpty(name) && name.StartsWith(startingLetter.ToString()));
    }

    public static void Main(string[] args)
    {
        var xml =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<folder name=\"c\">" +
            "   <folder name=\"program files\">" +
            "       <folder name=\"uninstall information\" />" +
            "   </folder>" +
            "   <folder name=\"users\" />" +
            "</folder>";

        foreach (var name in FolderNames(xml, 'u'))
            Console.WriteLine(name);
    }
}

/*

Implement a function FolderNames, which accepts a string containing an XML file that specifies folder structure and returns all folder names that start with startingLetter. The XML format is given in the example below.

For example, for the letter 'u' and XML file:

<?xml version="1.0" encoding="UTF-8"?>
<folder name="c">
    <folder name="program files">
        <folder name="uninstall information" />
    </folder>
    <folder name="users" />
</folder>

the function should return "uninstall information" and "users" (in any order).

*/
