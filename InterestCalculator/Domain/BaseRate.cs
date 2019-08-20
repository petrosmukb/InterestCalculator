using System;
using System.Collections.Generic;
using System.Text;

namespace InterestCalculator.Domain
{
    public class BaseRate
    {
        public decimal From { get; set; }
        public decimal? To { get; set; }
        public decimal Rate { get; set; }

        public BaseRate()
        {}

        public BaseRate(decimal from, decimal? to, decimal rate)
        {
            this.From = from;
            this.To = to;
            this.Rate = rate;
        }

        public decimal GetInterestRate(decimal balance)
        {
            if (balance == 0)
                return 0;
           
            return decimal.Round((Rate / 100) * balance, 2, MidpointRounding.AwayFromZero);
        }
    }
}
