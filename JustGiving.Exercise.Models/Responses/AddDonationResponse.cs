using System;
using System.Collections.Generic;
using System.Text;

namespace JustGiving.Exercise.Models.Responses
{
    public class AddDonationResponse
    {
        public Guid Id { get; set; }
        public decimal GiftAidAmount { get; set; }
    }
}
