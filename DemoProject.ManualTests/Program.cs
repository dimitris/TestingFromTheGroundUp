using DemoProject.ManualTests.Taxation;
using System;

namespace DemoProject.ManualTests
{
    class Program
    {
        /// <summary>
        /// Manual test runner.
        /// On visual studio Solution Explorer window right click on DemoProject.ManualTests,
        /// click "Set as StartUp Project" then press F5
        /// </summary>
        static void Main(string[] args)
        {
            TaxCalculatorManualTests taxCalculatorManualTests = new TaxCalculatorManualTests();

            Console.WriteLine($"Running test: {nameof(TaxCalculatorManualTests.GetProfitsTax_WithBetAmount10AndOdd510_ReturnsZero)}");
            taxCalculatorManualTests.GetProfitsTax_WithBetAmount10AndOdd510_ReturnsZero();

            Console.WriteLine($"Running test: {nameof(TaxCalculatorManualTests.GetProfitsTax_WithBetAmount5AndOdd1250_Returns186And75)}");
            taxCalculatorManualTests.GetProfitsTax_WithBetAmount5AndOdd1250_Returns186And75();

            Console.WriteLine("Tests completed. Press any key to continue.");
            Console.ReadKey();
        }
    }
}