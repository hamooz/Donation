using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JustGiving.Exercise.Data
{
    public class Repository: IRepository
    {
        protected readonly DonationDbContext dbContext;
        public Repository(DonationDbContext context)
        {
            dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Guid Add(Donation entity) 
        {
            entity.Id = Guid.NewGuid();
            dbContext.Donations.Add(entity);
            dbContext.SaveChanges();
            return entity.Id;
        }
        public int CountAll() 
        {
            return this.dbContext.Donations.Count();
        }
    }
}
