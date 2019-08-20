using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterestCalculator.Domain;

namespace InterestCalculator.DataAccess
{
    public class BaseRateRepository : IBaseRateRepository
    {
        private readonly IEnumerable<BaseRate> _baseRates;

        public BaseRateRepository()
        {
            _baseRates = new List<BaseRate>()
            {
                new BaseRate(0m, 1000m, 1.0m),
                new BaseRate(1001m, 5000m, 1.5m),
                new BaseRate(5001m, 10000m, 2.0m),
                new BaseRate(10001m, 50000m, 2.5m),
                new BaseRate(50001m, null, 3.0m)
            };
        }

        public BaseRate GetBaseRateForBalance(decimal balance)
        {
            return _baseRates
                .OrderBy(x => x.From)
                .Where(x => x.From >= balance)
                .FirstOrDefault();
        }
    }
}
