using InterestCalculator.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace InterestCalculator.Tests.Domain
{
    public class BaseRateTest
    {
        [Theory]
        [InlineData(1, 0, 0)]
        [InlineData(1, 1000, 10)]
        [InlineData(1.5, 1001, 15.02)]
        [InlineData(2, 5001, 100.02)]
        [InlineData(2.5, 10001, 250.03)]
        [InlineData(3, 50001, 1500.03)]
        public void BaseRate_GetInterestRate_Should_Return_Correct_Reate(decimal rate, decimal balance, decimal expected)
        {
            //Arrange
            var _sut = new BaseRate() { Rate = rate };

            //Act
            var interest = _sut.GetInterestRate(balance);

            //Assert
            Assert.Equal(expected, interest);
        }
    }
}
