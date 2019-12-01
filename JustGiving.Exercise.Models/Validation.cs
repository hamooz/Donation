using JustGiving.Exercise.ConfigurationHelper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustGiving.Exercise.Models
{
    public class Validation : IValidation
    {
        private Config _config;
        private string errorMessageLessThanMinimum;
        private string errorMessageMoreThanMaximum;
        
        public Validation(IOptions<Config> options)
        {
            _config = options.Value ?? throw new ArgumentNullException(nameof(options));
            errorMessageLessThanMinimum = $"Ammount should be equal or more than {_config.MinInput}";
            errorMessageMoreThanMaximum = $"Ammount should be equal or less than {_config.MaxInput}";
        }
        public ValidationResult Validate(decimal amount)
        {
            ValidationResult result = new ValidationResult()
            {
                IsValid = true,
                ErrorList = new List<string>()
            };
            if (amount< _config.MinInput )
            {
                result.ErrorList.Add(errorMessageLessThanMinimum);     
            }
            if (amount > _config.MaxInput)
            {
                result.ErrorList.Add(errorMessageMoreThanMaximum);
            }

            if (result.ErrorList.Count>0)
            {
                result.IsValid = false;
            }
            return result;
        }
    }
}
