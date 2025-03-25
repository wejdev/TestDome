namespace TestDome;

class TwoSum
{
    public static Tuple<int, int>? FindTwoSum(List<int> list, int sum)
    {
        var map = new Dictionary<int, int>();

        for (var i = 0; i < list.Count; i++)
        {
            var missingNumber = sum - list[i];
            if (map.TryGetValue(missingNumber, out var index))
            {
                return Tuple.Create(index, i);
            }

            map[list[i]] = i;
        }

        return null;
    }

    public static void Main(string[] args)
    {
        var indices = FindTwoSum(new List<int>() { 3, 1, 5, 7, 5, 9 }, 10);
        if (indices != null)
        {
            Console.WriteLine(indices.Item1 + " " + indices.Item2);
        }
    }
}
