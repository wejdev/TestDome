namespace TestDome;

public class Node
{
    public Node(int value, Node? left = null, Node? right = null)
    {
        Value = value;
        Left = left;
        Right = right;
    }

    public int Value { get; set; }

    public Node? Left { get; set; }

    public Node? Right { get; set; }
}

public class BinarySearchTree
{
    public static bool Contains(Node? root, int value)
    {
        while (root != null)
        {
            if (value == root.Value)
                return true;

            if (value < root.Value)
                root = root.Left;
            else
                root = root.Right;
        }

        return false;
    }

    public static bool ContainsRecursive(Node? root, int value)
    {
        if (root == null)
            return false;

        if (root.Value == value)
            return true;

        if (value < root.Value)
            return Contains(root.Left, value);
        return Contains(root.Right, value);
    }

    public static void Main(string[] args)
    {
        var n1 = new Node(1);
        var n3 = new Node(3);
        var n2 = new Node(2, n1, n3);

        Console.WriteLine(Contains(n2, 3));
    }
}

/*

    **Binary search tree (BST)** is a binary tree where the value of each node is larger or equal to the values in all the nodes in that node's left subtree and is smaller than the values in all the nodes in that node's right subtree.

    Write a function that, **efficiently** with respect to time used, checks if a given binary search tree contains a given value.

    For example, for the following tree:

- n1 (Value: 1, Left: null, Right: null)
    - n2 (Value: 2, Left: n1, Right: n3)
    - n3 (Value: 3, Left: null, Right: null)

Call to `Contains(n2, 3)` should return `true` since a tree with root at `n2` contains number `3`.

*/
