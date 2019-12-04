using System;
using System.Collections.Generic;
using System.Text;

namespace JustGiving.Exercise.Data
{
    public class Donation
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string Postcode { get; set; }    
        public decimal Amount { get; set; }
    }
}
