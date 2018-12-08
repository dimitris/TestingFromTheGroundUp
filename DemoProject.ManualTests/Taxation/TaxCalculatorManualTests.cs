using DemoProject.Taxation;
using System;

namespace DemoProject.ManualTests.Taxation
{
    public class TaxCalculatorManualTests
    {
        public void GetProfitsTax_WithBetAmount10AndOdd510_ReturnsZero()
        {
            // Arrange
            decimal betAmount = 10;
            decimal odd = 510;
            TaxCalculator sut = new TaxCalculator();
            decimal expected = 0;

            // Act
            decimal actual = sut.GetProfitsTax(betAmount, odd);

            // Assert
            if (actual != expected)
            {
                throw new Exception($"Test failed. Actual was {actual}, expected was {expected}");
            }
        }
        
        public void GetProfitsTax_WithBetAmount5AndOdd1250_Returns186And75()
        {
            // Arrange
            decimal betAmount = 5;
            decimal odd = 1250;
            TaxCalculator sut = new TaxCalculator();
            decimal expected = 186.75m;

            // Act
            decimal actual = sut.GetProfitsTax(betAmount, odd);

            // Assert
            if (actual != expected)
            {
                throw new Exception($"Test failed. Actual was {actual}, expected was {expected}");
            }
        }
    }
}