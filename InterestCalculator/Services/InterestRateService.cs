using InterestCalculator.DataAccess;
using System;

namespace InterestCalculator.Services
{
    public class InterestRateService : IInterestRateService
    {
        private readonly IBaseRateRepository _baseRateRepository;

        public InterestRateService(IBaseRateRepository baseRateRepository)
        {
            _baseRateRepository = baseRateRepository ?? throw new ArgumentNullException(nameof(baseRateRepository));
        }

        public decimal GetInterestRate(decimal balance)
        {
            if (balance <= 0)
                return 0;

            var baseRate = _baseRateRepository.GetBaseRateForBalance(balance);

            if (baseRate == null)
                throw new Exception("No base rate found for balance");

           return baseRate.GetInterestRate(balance);
        }
    }
}
