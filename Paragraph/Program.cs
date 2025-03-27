using System.Text.RegularExpressions;

namespace TestDome;

public class Paragraph
{
    public static string ChangeFormat(string paragraph)
    {
        const string regex = @"(\d{3})-(\d{2})-(\d{4})";
        var changed = Regex.Replace(paragraph, regex,
            match => match.Groups[1].Value + "/" + match.Groups[3].Value + "/" + match.Groups[2].Value);

        return changed;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(ChangeFormat("Your long-term policy number is 112-39-8552."));
    }
}
