using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustGiving.Exercise.CalculatorService;
using Microsoft.AspNetCore.Mvc;

namespace JustGiving.Exercise.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftAidController : ControllerBase
    {
        private ICalculator _calculator;
        public GiftAidController(ICalculator calculator) 
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }
         
        [HttpGet]
        public ActionResult<decimal> Get()
        {
            
            return _calculator.CalculateGiftAid(100);
        }
    }
}
