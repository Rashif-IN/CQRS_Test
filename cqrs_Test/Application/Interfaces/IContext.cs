using System;
using System.Threading;
using System.Threading.Tasks;
using cqrs_Test.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace cqrs_Test.Application.Interfaces
{
    public interface IContext
    {
        public DbSet<Customers> Customer { get; set; }
        public DbSet<Products> Product { get; set; }
        public DbSet<CustomerPaymentCards> CPC { get; set; }
        public DbSet<Merchants> merhcants { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
