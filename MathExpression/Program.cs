namespace TestDome;

internal class MathExpression
{
    public static bool IsBalancedOrig(string parenthesis)
    {
        var stack = new Stack<char>();
        var opening = new HashSet<char> { '(', '[', '{' };
        var closing = new HashSet<char> { ')', ']', '}' };
        var pairs = new Dictionary<char, char>
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };

        foreach (var c in parenthesis)
            if (opening.Contains(c))
            {
                stack.Push(c);
            }
            else if (closing.Contains(c))
            {
                if (stack.Count == 0 || stack.Peek() != pairs[c])
                    return false;

                stack.Pop();
            }

        return stack.Count == 0;
    }

    public static bool IsBalanced(string input)
    {
        var stack = new Stack<char>();
        var pairs = new Dictionary<char, char>
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };

        foreach (var c in input)
            if (pairs.Values.Contains(c))
                stack.Push(c);
            else if (pairs.TryGetValue(c, out var expectedOpen))
                if (stack.Count == 0 || stack.Pop() != expectedOpen)
                    return false;

        return stack.Count == 0;
    }


    private class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
