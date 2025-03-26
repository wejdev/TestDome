namespace TestDome;

public class SortedSearch
{
    public static int CountNumbers(int[] sortedArray, int lessThan)
    {
        var left = 0;
        var right = sortedArray.Length;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (sortedArray[mid] < lessThan)
                left = mid + 1;
            else
                right = mid;
        }

        return left;
    }


    public static void Main(string[] args)
    {
        Console.WriteLine(CountNumbers(new[] { 1, 3, 5, 7 }, 4));
    }
}
/*

Implement function `CountNumbers` that accepts a sorted array of unique integers and,
**efficiently** with respect to time used, counts the number of array elements that
 are less than the parameter `lessThan`.

For example, `SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7 }, 4)` should return `2`
because there are two array elements less than `4`.

*/
