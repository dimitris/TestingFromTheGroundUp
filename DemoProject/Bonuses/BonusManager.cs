using System;

namespace DemoProject.Bonuses
{
    public class BonusManager
    {
        public bool ShouldGetBirthdayBonus(Customer customer, DateTime dateTimeToCheck)
        {
            if (customer == null || customer != null && customer.DateOfBirth == default(DateTime))
            {
                return false;
            }

            if (customer.DateOfBirth.Month == 2 && customer.DateOfBirth.Day == 29)
            {
                if (!DateTime.IsLeapYear(dateTimeToCheck.Year))
                {
                    return (dateTimeToCheck.Month == 2 && dateTimeToCheck.Day == 28);
                }
            }

            return ((customer.DateOfBirth.Month == dateTimeToCheck.Month)
                && customer.DateOfBirth.Day == dateTimeToCheck.Day);
        }
    }
}