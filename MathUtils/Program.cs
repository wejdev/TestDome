namespace TestDome;

public class MathUtils
{
    public static double Average(int a, int b)
    {
        return (a + b) / 2.0;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(Average(2, 1));
    }
}
