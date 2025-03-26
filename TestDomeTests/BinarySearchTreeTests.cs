using JetBrains.Annotations;
using TestDome;

namespace TestDomeTests;

[TestSubject(typeof(BinarySearchTree))]
public class BinarySearchTreeTests
{
    public static IEnumerable<object[]> ContainsTestCases =>
        new List<object[]>
        {
            new object[]
            {
                BuildTree(), // custom method to return root node
                3,
                true
            }
        };

    private static Node BuildTree()
    {
        var n1 = new Node(1);
        var n3 = new Node(3);
        var n2 = new Node(2, n1, n3);

        return n2;
    }

    [Theory]
    [MemberData(nameof(ContainsTestCases))]
    public void ContainsTest(Node root, int value, bool expected)
    {
        var actual = BinarySearchTree.Contains(root, value);
        Assert.Equal(expected, actual);
    }
}
