using DemoProject.Taxation;
using Xunit;

namespace DemoProject.Tests.Taxation
{
    public class TaxCalculatorTests
    {
        [Theory]
        [InlineData(10, 510, 0)] // 0%
        [InlineData(5, 1250, 186.75)] // 15%, 0%
        [InlineData(5, 10000, 7999)] // 20%, 15%, 0%
        [InlineData(10, 1000, 0)] // Taxable amount of net profit per column 99.99
        [InlineData(10, 1001, 0)] // Taxable amount of net profit per column 100
        [InlineData(10, 1001.1, 0.15)] // Taxable amount of net profit per column 100.01
        [InlineData(10, 1500, 748.5)] // Taxable amount of net profit per column 149.9
        [InlineData(10, 5000.9, 5999.85)] // Taxable amount of net profit per column 499.99
        [InlineData(10, 5001, 6000)] // Taxable amount of net profit per column 500
        [InlineData(10, 5001.1, 6000.20)] // Taxable amount of net profit per column 500.01
        [InlineData(10, 5500, 6998)] // Taxable amount of net profit per column 549.9
        public void GetProfitsTax_InEveryTaxLevel_ReturnsExpectedTax(decimal betAmount, decimal odd, decimal expected)
        {
            // Arrange
            TaxCalculator sut = new TaxCalculator();

            // Act
            decimal actual = sut.GetProfitsTax(betAmount, odd);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}