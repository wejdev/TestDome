﻿namespace TestDome;

internal class Account
{
    [Flags]
    public enum Access
    {
        Delete = 1 << 0,
        Publish = 1 << 1,
        Submit = 1 << 2,
        Comment = 1 << 3,
        Modify = 1 << 4,

        Writer = Submit | Modify,
        Editor = Delete | Publish | Comment,
        Owner = Writer | Editor
    }


    public static void Main(string[] args)
    {
        Console.WriteLine(Access.Writer.HasFlag(Access.Delete)); //Should print: "False"
    }
}

/*

Each account on a website has a set of access flags that represent a users access.
Update and extend the enum so that it contains three new access flags:
    * A Writer access flag that is made up of the Submit and Modify flags.
    * An Editor access flag that is made up of the Delete, Publish and Comment flags.
    * An Owner access that is made up of the Writer and Editor flags.

For example, the code below should print "False" as the Writer flag does not contain the Delete flag.
    Console.WriteLine(Access.Writer.HasFlag(Access.Delete))

*/
