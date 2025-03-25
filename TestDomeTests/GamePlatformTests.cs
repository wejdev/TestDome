using GamePlatform;
using JetBrains.Annotations;

namespace TestDomeTests;

[TestSubject(typeof(GamePlatform.GamePlatform))]
public class GamePlatformTests
{

    [Theory]
    [InlineData(60,new[] { 0, 30, 0, -45, 0 }, 75)]
    [InlineData(0,new[] { 20, -30, 10, -45, 0 }, 45)]
    public void CalculateFinalSpeed_GivenInputAndS(double initialSpeed, int[] inclinations, double expected)
    {
        // Act
        var actual = GamePlatform.GamePlatform.CalculateFinalSpeed(initialSpeed, inclinations);

        // Assert
        Assert.Equal(expected, actual);
    }
}
