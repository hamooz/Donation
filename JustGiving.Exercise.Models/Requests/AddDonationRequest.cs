using System;
using System.Collections.Generic;
using System.Text;

namespace JustGiving.Exercise.Models.Requests
{
    public class AddDonationRequest
    {
        public string Fullname { get; set; }
        public string Postcode { get; set; }
        public decimal Amount { get; set; }
    }
}
