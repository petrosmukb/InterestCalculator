using InterestCalculator.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterestCalculator.DataAccess
{
    public interface IBaseRateRepository
    {
        BaseRate GetBaseRateForBalance(decimal balance);
    }
}
