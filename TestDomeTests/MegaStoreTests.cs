using JetBrains.Annotations;

namespace TestDomeTests;

[TestSubject(typeof(MegaStore))]
public class MegaStoreTests
{
    [Theory]
    [InlineData(12, 100, MegaStore.DiscountType.Weight, 82)]
    [InlineData(1, 100, MegaStore.DiscountType.Weight, 94)]
    [InlineData(12, 100, MegaStore.DiscountType.Standard, 94)]
    [InlineData(12, 100, MegaStore.DiscountType.Seasonal, 88)]
    public void CalculateFinalSpeed_GivenInputAndS(double cartWeight,
        double totalPrice,
        MegaStore.DiscountType discountType,
        double expected)
    {
        // Act
        var actual = MegaStore.GetDiscountedPrice(cartWeight, totalPrice, discountType);

        // Assert
        Assert.Equal(expected, actual);
    }
}
