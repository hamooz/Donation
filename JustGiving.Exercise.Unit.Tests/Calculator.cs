using NUnit.Framework;
using NSubstitute;
using JustGiving.Exercise.ConfigurationHelper;
using Microsoft.Extensions.Options;
using JustGiving.Exercise.CalculatorService;


namespace JustGiving.Exercise.Unit.Tests
{
    public class CalculatorTests
    {
        IOptions<Config> config = Options.Create(new Config());

        [SetUp]
        public void Setup()
        {
            config.Value.TaxRate = 20.0M;
        }

        [TestCase(100, 25)]
        [TestCase(200, 50)]
        public void Should_Return_Correct_GIFT_AID_For_Given_Ammount(decimal ammount, decimal expected)
        {
            var Calculator = new Calculator(config);
            var actual = Calculator.CalculateGiftAid(ammount);
            Assert.AreEqual(actual, expected);
        }
    }
}