using JustGiving.Exercise.ConfigurationHelper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;

namespace JustGiving.Exercise.CalculatorService
{
    public class Calculator : ICalculator
    {
        private Config _config;
        
        public Calculator(IOptions<Config> options)
        {
            _config = options.Value?? throw new ArgumentNullException(nameof(options));
        }
        public decimal CalculateGiftAid(decimal donationAmount)
        {
            return donationAmount * (_config.TaxRate / (100 - _config.TaxRate));
        }
    }
}
