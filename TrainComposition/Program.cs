namespace TestDome;

public class TrainComposition
{
    public LinkedList<int> Wagons { get; } = new();

    public void AttachWagonFromLeft(int wagonId)
    {
        Wagons.AddFirst(wagonId);
    }

    public void AttachWagonFromRight(int wagonId)
    {
        Wagons.AddLast(wagonId);
    }

    public int DetachWagonFromLeft()
    {
        if (Wagons.First == null)
            throw new InvalidOperationException("No wagons to detach.");

        var firstValue = Wagons.First.Value;
        Wagons.RemoveFirst();
        return firstValue;
    }

    public int DetachWagonFromRight()
    {
        if (Wagons.Last == null)
            throw new InvalidOperationException("No wagons to detach.");

        var lastValue = Wagons.Last.Value;
        Wagons.RemoveLast();
        return lastValue;
    }

    public static void Main(string[] args)
    {
        var train = new TrainComposition();
        train.AttachWagonFromLeft(7);
        train.AttachWagonFromLeft(13);
        Console.WriteLine(train.DetachWagonFromRight()); // 7
        Console.WriteLine(train.DetachWagonFromLeft()); // 13
    }
}
