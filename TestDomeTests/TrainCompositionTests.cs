using JetBrains.Annotations;
using TestDome;

namespace TestDomeTests;

[TestSubject(typeof(TrainComposition))]
public class TrainCompositionTests
{
    [Fact]
    public void MainSampleTest()
    {
        var train = new TrainComposition();
        train.AttachWagonFromLeft(7);
        train.AttachWagonFromLeft(13);

        int[] expected = [13, 7];
        Assert.Equal(expected, train.Wagons);

        expected = [13];
        var fromRight = train.DetachWagonFromRight();
        Assert.Equal(expected, train.Wagons);
        Assert.Equal(7, fromRight);

        expected = [];
        var fromLeft = train.DetachWagonFromLeft();
        Assert.Equal(expected, train.Wagons);
        Assert.Equal(13, fromLeft);
    }

    [Fact]
    public void AttachWagonFromLeftTest()
    {
        var train = new TrainComposition();
        train.AttachWagonFromLeft(7);

        int[] expected = [7];

        Assert.Equal(expected, train.Wagons);

        train.AttachWagonFromLeft(6);
        train.AttachWagonFromLeft(5);

        expected = [5, 6, 7];

        Assert.Equal(expected, train.Wagons);
    }

    [Fact]
    public void AttachWagonFromRightTest()
    {
        var train = new TrainComposition();
        train.AttachWagonFromRight(7);

        int[] expected = [7];

        Assert.Equal(expected, train.Wagons);

        train.AttachWagonFromRight(8);
        train.AttachWagonFromRight(9);

        expected = [7, 8, 9];

        Assert.Equal(expected, train.Wagons);
    }

    [Fact]
    public void DetachWagonFromLeftTest()
    {
        var train = new TrainComposition();
        train.AttachWagonFromLeft(7);
        train.AttachWagonFromLeft(6);
        train.AttachWagonFromLeft(5);

        int[] expected = [5, 6, 7];
        Assert.Equal(expected, train.Wagons);

        var fromLeft = train.DetachWagonFromLeft();
        Assert.Equal(5, fromLeft);
        expected = [6, 7];
        Assert.Equal(expected, train.Wagons);
    }

    [Fact]
    public void DetachWagonFromRight()
    {
        var train = new TrainComposition();
        train.AttachWagonFromRight(7);
        train.AttachWagonFromRight(8);
        train.AttachWagonFromRight(9);

        int[] expected = [7, 8, 9];
        Assert.Equal(expected, train.Wagons);

        var fromRight = train.DetachWagonFromRight();
        Assert.Equal(9, fromRight);
        expected = [7, 8];
        Assert.Equal(expected, train.Wagons);
    }


    [Fact]
    public void DetatchLeft_Throws_WhenListIsEmpty()
    {
        var train = new TrainComposition();

        Assert.Throws<InvalidOperationException>(() => train.DetachWagonFromLeft());
    }

    [Fact]
    public void DetatchRight_Throws_WhenListIsEmpty()
    {
        var train = new TrainComposition();

        Assert.Throws<InvalidOperationException>(() => train.DetachWagonFromRight());
    }
}
