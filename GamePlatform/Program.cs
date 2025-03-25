namespace GamePlatform;

internal class GamePlatform
{
    public static double CalculateFinalSpeed(double initialSpeed, int[] inclinations)
    {
/*
        for (int i = 0; i < inclinations.Length; i++)
        {
            finalSpeed -= inclinations[i];
        }
        return finalSpeed;
        double totalInclination  =0;

        for (int i = 0; i < inclinations.Length; i++)
        {
            totalInclination += inclinations[i];
        }
        return initialSpeed - totalInclination;
 */
        return initialSpeed - inclinations.Sum();
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(CalculateFinalSpeed(60, new int[] { 0, 30, 0, -45, 0 }));
    }
}

