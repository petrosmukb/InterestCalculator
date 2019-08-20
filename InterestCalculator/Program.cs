using InterestCalculator.DataAccess;
using InterestCalculator.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace InterestCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddTransient<IInterestRateService, InterestRateService>()
            .AddTransient<IBaseRateRepository, BaseRateRepository>()       
            .BuildServiceProvider();

            var service = serviceProvider.GetService<IInterestRateService>();

            Console.WriteLine("Enter amount..");
            var amount = Console.ReadLine();

            if (decimal.TryParse(amount, out decimal m))
                Console.WriteLine(service.GetInterestRate(m));

            Console.ReadLine();
        }
    }
}
