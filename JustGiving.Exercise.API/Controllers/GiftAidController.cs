using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustGiving.Exercise.CalculatorService;
using JustGiving.Exercise.Models;
using JustGiving.Exercise.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JustGiving.Exercise.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftAidController : ControllerBase
    {
        private IValidation _validation;
        private ICalculator _calculator;
        public GiftAidController(ICalculator calculator, IValidation validation) 
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
            _validation = validation ?? throw new ArgumentNullException(nameof(validation));
        }
        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        [Produces("application/json")]  
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(decimal amount)
        {
            var validationResult = _validation.Validate(amount);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ErrorList);
            }
            return Ok(new GiftAidResponse()
            {
                DonationAmount = amount,
                GiftAidAmount = _calculator.CalculateGiftAid(amount)
            });
        }
    }
}
