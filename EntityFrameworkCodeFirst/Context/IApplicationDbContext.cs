using EntityFrameworkCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCodeFirst.Context
{
    public interface IApplicationDbContext
    {
        DbSet<Student> Students { get; set; }

        Task<int> SaveChanges();
    }
}