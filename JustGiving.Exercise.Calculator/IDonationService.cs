using System;
using JustGiving.Exercise.Data;

namespace JustGiving.Exercise.Business
{
    public interface IDonationService
    {
        Guid AddDonation(Donation donation);
    }
}