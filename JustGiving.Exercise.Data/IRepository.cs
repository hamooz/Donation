using System;
using System.Threading.Tasks;

namespace JustGiving.Exercise.Data
{
    public interface IRepository
    {
        Guid Add(Donation donation);
        int CountAll();
    }
}
