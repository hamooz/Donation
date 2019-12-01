using JustGiving.Exercise.ConfigurationHelper;
using JustGiving.Exercise.Models;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustGiving.Exercise.Unit.Tests
{
    public class ValidationTests
    {
        IOptions<Config> config = Options.Create(new Config());

        [SetUp]
        public void Setup()
        {
            config.Value.TaxRate = 20.0M;
            config.Value.MaxInput = 100000000.0M;
            config.Value.MinInput = 2.0M;
        }
        [TestCase(-100, false)]
        [TestCase(0, false)]
        [TestCase(1, false)]
        [TestCase(2, true)]
        [TestCase(2,true)]
        [TestCase(200, true)]
        [TestCase(100000000.00, true)]
        [TestCase(100000000.01, false)]
        public void Should_Return_Correct_Validation_Result(decimal ammount, bool expected)
        {
            var validation = new Validation(config);
            var actual = validation.Validate(ammount);
            Assert.AreEqual(actual.IsValid, expected);
        }
        [TestCase(1, "Ammount should be equal or more than 2.0")]
        [TestCase(100000000.1, "Ammount should be equal or less than 100000000.0")]
        public void Should_Return_Correct_Validation_Error(decimal ammount, string expected)
        {
            var validation = new Validation(config);
            var actual = validation.Validate(ammount);
            Assert.AreEqual(actual.ErrorList[0], expected);
        }
        [TestCase(100000, 0)]
        public void Should_Return_Empty_Validation_ErrorList(decimal ammount, int expected)
        {
            var validation = new Validation(config);
            var actual = validation.Validate(ammount);
            Assert.AreEqual(actual.ErrorList.Count, expected);
        }
    }
}
