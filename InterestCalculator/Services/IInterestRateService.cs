using System;
using System.Collections.Generic;
using System.Text;

namespace InterestCalculator.Services
{
    public interface IInterestRateService
    {
        decimal GetInterestRate(decimal balance);
    }
}
