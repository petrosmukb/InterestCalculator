using InterestCalculator.DataAccess;
using InterestCalculator.Domain;
using InterestCalculator.Services;
using Moq;
using System;
using Xunit;

namespace InterestCalculator.Tests
{
    public class InterestRateServiceTest
    {
        private readonly Mock<IBaseRateRepository> _baseRateRepository;
        private readonly IInterestRateService _sut;

        public InterestRateServiceTest()
        {
            _baseRateRepository = new Mock<IBaseRateRepository>();
            _sut = new InterestRateService(_baseRateRepository.Object);
        }

        [Fact]
        public void Should_Throw_Exception_When_No_Base_Rate_Found()
        {
            //Arrange
            _baseRateRepository.Setup(x => x.GetBaseRateForBalance(1000)).Returns((BaseRate)null);

            //Act & Assert
            Exception ex = Assert.Throws<Exception>(() => _sut.GetInterestRate(1000));
            Assert.Equal("No base rate found for balance", ex.Message);
        }

        [Fact]
        public void Should_Return_Zero_When_Input_Is_Less_Than_Zero()
        {
            //Arrange
            decimal balance = -10m;
            _baseRateRepository.Setup(x => x.GetBaseRateForBalance(balance)).Returns((BaseRate)null);

            //Act & Assert
            var result = _sut.GetInterestRate(balance);

            Assert.Equal(0, result);
        }
    }
}
