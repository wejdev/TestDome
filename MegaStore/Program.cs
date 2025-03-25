public class MegaStore
{
    public enum DiscountType
    {
        Standard,
        Seasonal,
        Weight
    }

    public static double GetDiscountedPrice(double cartWeight,
        double totalPrice,
        DiscountType discountType)
    {
        var discountPercentage = discountType switch
        {
            DiscountType.Standard => 0.06,
            DiscountType.Seasonal => 0.12,
            DiscountType.Weight => cartWeight <= 10 ? 0.06 : 0.18
        };

        var pricePercentage = 1 - discountPercentage;

        return totalPrice * pricePercentage;
    }


    public static void Main(string[] args)
    {
        Console.WriteLine(GetDiscountedPrice(12, 100, DiscountType.Weight));
    }
}
