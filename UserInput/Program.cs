namespace TestDome;

public class TextInput
{
    private string _strValue;

    public TextInput()
    {
        _strValue = "";
    }

    public TextInput(string initialStr)
    {
        _strValue = initialStr;
    }

    public virtual void Add(char c)
    {
        _strValue += c;
    }

    public string GetValue()
    {
        return _strValue;
    }
}

public class NumericInput : TextInput
{
    public NumericInput()
    {
    }

    public NumericInput(string initialStr) : base(initialStr)
    {
    }

    public override void Add(char c)
    {
        if (char.IsDigit(c))
            base.Add(c);
    }
}

internal class UserInput
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
