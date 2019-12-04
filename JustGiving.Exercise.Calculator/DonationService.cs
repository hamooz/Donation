using JustGiving.Exercise.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustGiving.Exercise.Business
{
    public class DonationService : IDonationService
    {
        private IRepository _repository { get; set; }
        public DonationService(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public Guid AddDonation(Donation donation)
        {
            return _repository.Add(donation);
        }
    }
}
