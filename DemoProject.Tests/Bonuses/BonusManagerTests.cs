using DemoProject.Bonuses;
using System;
using System.Collections.Generic;
using Xunit;

namespace DemoProject.Tests.Bonuses
{
    public class BonusManagerTests
    {
        [Theory]
        [MemberData(nameof(ShouldGetBirthdayBonus_Data))]
        public void ShouldGetBirthdayBonus_WithVariousCustomers_ReturnsExpectedResult(Customer customer, DateTime dateTimeToCheck, bool expected)
        {
            // Arrange
            BonusManager sut = new BonusManager();

            // Act
            bool actual = sut.ShouldGetBirthdayBonus(customer, dateTimeToCheck);

            // Assert
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> ShouldGetBirthdayBonus_Data => new object[][]
        {
            new object[]
            {
                new Customer() { Name = "Peter", DateOfBirth = new DateTime(1994, 11, 3) },
                new DateTime(2017, 11, 13),
                false
            },
            new object[]
            {
                new Customer() { Name = "John", DateOfBirth = new DateTime(1989, 1, 25) },
                new DateTime(2017, 1, 25),
                true
            },
            new object[]
            {
                new Customer() { Name = "Mary", DateOfBirth = new DateTime(1985, 8, 12) },
                new DateTime(2019, 8, 12),
                true
            },
            new object[]
            {
                new Customer() { Name = "Nick", DateOfBirth = new DateTime(1996, 2, 29) },
                new DateTime(2000, 2, 29),
                true
            },
            new object[]
            {
                new Customer() { Name = "Nick", DateOfBirth = new DateTime(1996, 2, 29) },
                new DateTime(2001, 2, 28),
                true
            }
        };
    }
}