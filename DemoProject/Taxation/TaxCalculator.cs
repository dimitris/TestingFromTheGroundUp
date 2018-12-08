using System;

namespace DemoProject.Taxation
{
    public class TaxCalculator
    {
        /// <summary>
        /// Returns the tax for a winning bet
        /// </summary>
        /// <param name="betAmount">The amount of the bet</param>
        /// <param name="odd">The odds of the bet</param>
        public decimal GetProfitsTax(decimal betAmount, decimal odd)
        {
            decimal profits = betAmount * odd;
            decimal netProfits = profits - betAmount;
            decimal numberOfColumnsInThisBet = betAmount / 0.10m;
            decimal netProfitsPerColumn = netProfits / numberOfColumnsInThisBet;
            decimal taxableAmountOfNetProfitsPerColumn, taxationPercentage;

            decimal totalTaxableAmount = 0;

            if (netProfitsPerColumn >= 500.01m) 
            {
                taxableAmountOfNetProfitsPerColumn = netProfitsPerColumn - 500.00m;
                taxationPercentage = 0.20m;
                totalTaxableAmount += taxableAmountOfNetProfitsPerColumn * numberOfColumnsInThisBet * taxationPercentage;
            }
            if (netProfitsPerColumn >= 100.01m)
            {
                taxableAmountOfNetProfitsPerColumn = Math.Min(500, netProfitsPerColumn) - 100.00m;
                taxationPercentage = 0.15m;
                totalTaxableAmount += taxableAmountOfNetProfitsPerColumn * numberOfColumnsInThisBet * taxationPercentage;
            }
            else
            {
                taxableAmountOfNetProfitsPerColumn = 0;
                taxationPercentage = 0;
                totalTaxableAmount += taxableAmountOfNetProfitsPerColumn * numberOfColumnsInThisBet * taxationPercentage;
            }
            return totalTaxableAmount;
        }

        /// <summary>
        /// Returns the tax for a winning bet
        /// </summary>
        /// <param name="betAmount">The amount of the bet</param>
        /// <param name="odd">The odds of the bet</param>
        public decimal GetProfitsTax_AlternativeImplementation(decimal betAmount, decimal odd)
        {
            decimal netProfits = (betAmount * odd) - betAmount;
            decimal numberOfColumnsInThisBet = betAmount / 0.10m;
            decimal netProfitsPerColumn = netProfits / numberOfColumnsInThisBet;

            if (netProfitsPerColumn <= 100)
                return 0;

            decimal totalTaxableAmount = 0;

            if (netProfitsPerColumn >= 500.01m)
                totalTaxableAmount += ((netProfitsPerColumn - 500.00m) * 0.20m) * numberOfColumnsInThisBet;
            if (netProfitsPerColumn >= 100.01m)
                totalTaxableAmount += ((Math.Min(netProfitsPerColumn, 500.00m) - 100.00m) * 0.15m) * numberOfColumnsInThisBet;
            
            return totalTaxableAmount;
        }
    }
}










// auto apotelei meros mias megalis diadikasias den mporei na testaristei trexontas ena olokliro senario stoiximatos, settle, na psaksoume sti vasi klp

// tha dokimaso ena failing test opou tha thelei to KATHARO KERDOS ANA STILI (gia to sosto katharo kerdos tha prepei na afairei kai to arxiko bet apo ta kerdi)
// ena allo failing test tha einai oti i forologia tha prepei na efarmozetai klimakota kai oxi epi olou tou posou
// ena allo failing test pou dinei odd mikrotero apo 1
// i telospanton kataligei se arnitiko tax