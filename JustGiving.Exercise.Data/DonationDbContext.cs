using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustGiving.Exercise.Data
{
    public class DonationDbContext: DbContext
    {
        public DonationDbContext(DbContextOptions<DonationDbContext> options)
        : base(options)
        {
        
        }
        public DbSet<Donation> Donations { get; set; }

    }
}
