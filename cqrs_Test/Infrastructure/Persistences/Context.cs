using System;
using cqrs_Test.Application.Interfaces;
using cqrs_Test.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace cqrs_Test.Infrastructure.Persistences
{
    public class Contextt : DbContext, IContext
    {
        
        public Contextt(DbContextOptions<Contextt> opt) : base(opt) { }

        public DbSet<Customers> Customer { get; set; }
        public DbSet<Products> Product { get; set; }
        public DbSet<CustomerPaymentCards> CPC { get; set; }
        public DbSet<Merchants> merhcants { get; set; }

    }
}
