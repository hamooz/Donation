using JustGiving.Exercise.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace JustGiving.Exercise.Unit.Tests
{
    public class RepositoryTests
    {

        private Donation donation1, donation2;
        private DonationDbContext context;
        private Repository repository;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DonationDbContext>()
            .UseInMemoryDatabase(databaseName: "DonationDatabase")
            .Options;
            context = new DonationDbContext(options);

            donation1 = new Donation()
            {
                Amount = 100,
                Fullname = "Jon Doe",
                Postcode = "SE10 0EX"
            };
            donation2 = new Donation()
            {
                Amount = 102,
                Fullname = "John Doe",
                Postcode = "CR0 2AP"
            };
            repository = new Repository(context);
        }

        [Test]
        public void Should_Add_and_Save_When_CAlling_Repository_Add()
        {
            repository.Add(donation1);
            Assert.AreEqual(1, repository.CountAll());
        }
        [Test]
        public void Should_Assign_Unique_IDs_when_Calling_Add()
        {
            var id1 = repository.Add(donation1);
            var id2 = repository.Add(donation2);
            Assert.AreNotEqual(id1, id2);
        }
    }
}
