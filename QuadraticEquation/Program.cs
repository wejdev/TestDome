namespace TestDome;

public class QuadraticEquation
{
    public static Tuple<double, double> FindRoots(double a, double b, double c)
    {
        var discriminant = b * b - 4 * a * c;
        var sqrt = Math.Sqrt(discriminant);

        var root1 = (-b + sqrt) / (2 * a);
        var root2 = (-b - sqrt) / (2 * a);

        return new Tuple<double, double>(root1, root2);
    }


    public static void Main(string[] args)
    {
        var roots = FindRoots(2, 10, 8);
        Console.WriteLine("Roots: " + roots.Item1 + ", " + roots.Item2);
    }
}

/*

Implement the function `FindRoots` to find the roots of the quadratic equation: **ax² + bx + c = 0**. The function should return a tuple containing roots in any order. If the equation has only one solution, the function should return that solution as both elements of the tuple. The equation will always have at least one solution.

The roots of the quadratic equation can be found with the following formula:
![Formula image: x₁,₂ = (-b ± √(b² - 4ac)) / 2a]

For example, `FindRoots(2, 10, 8)` should return `(-1, -4)` or `(-4, -1)` as the roots of the equation `2x² + 10x + 8 = 0` are -1 and -4.

*/
