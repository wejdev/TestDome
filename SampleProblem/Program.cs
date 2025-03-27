namespace TestDome;

public class SampleProblem
{
    public static string FizzBuzz(int number)
    {
        if (number % 15 == 0)
            return "FizzBuzz";
        if (number % 3 == 0)
            return "Fizz";
        if (number % 5 == 0)
            return "Buzz";
        return number.ToString();
    }


    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
