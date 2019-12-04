using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustGiving.Exercise.Business;
using JustGiving.Exercise.CalculatorService;
using JustGiving.Exercise.Models;
using JustGiving.Exercise.Models.Requests;
using JustGiving.Exercise.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JustGiving.Exercise.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private IValidation _validation;
        private ICalculator _calculator;
        private IDonationService _donationService;
        public DonationController(ICalculator calculator, IValidation validation, IDonationService donationService)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
            _validation = validation ?? throw new ArgumentNullException(nameof(validation));
            _donationService = donationService ?? throw new ArgumentNullException(nameof(donationService));
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddDonation(AddDonationRequest donation)
        {
            var validationResult = _validation.Validate(donation.Amount);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ErrorList);
            }
            var id = _donationService.AddDonation(new Data.Donation()
            {
                Amount = donation.Amount,
                Fullname = donation.Fullname,
                Postcode = donation.Postcode
            });
            return Ok(new AddDonationResponse()
            {
                Id = id,
                GiftAidAmount = _calculator.CalculateGiftAid(donation.Amount)
            });
        }
    }
}