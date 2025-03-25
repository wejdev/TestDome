namespace GamePlatform;

internal class MathExpression
{
    public static bool IsBalancedOrig(string parenthesis)
    {
        Stack<char> stack = new Stack<char>();
        HashSet<char> opening = new HashSet<char> { '(', '[', '{' };
        HashSet<char> closing = new HashSet<char> { ')', ']', '}' };
        Dictionary<char, char> pairs = new Dictionary<char, char>
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };

        foreach (char c in parenthesis)
        {
            if (opening.Contains(c))
            {
                stack.Push(c);
            }
            else if (closing.Contains(c))
            {
                if (stack.Count == 0 || stack.Peek() != pairs[c])
                {
                    return false;
                }

                stack.Pop();
            }
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

        foreach (char c in input)
        {
            if (pairs.Values.Contains(c))
            {
                stack.Push(c);
            }
            else if (pairs.TryGetValue(c, out char expectedOpen))
            {
                if (stack.Count == 0 || stack.Pop() != expectedOpen)
                    return false;
            }
        }

        return stack.Count == 0;
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
