using Drugovich.Domain.Entities;
using Drugovich.Domain.Models.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugovich.Infrastructure
{
    public class DrugovichDbContext : DbContext
    {
        public DrugovichDbContext() : base()
        { }
        public DrugovichDbContext(DbContextOptions<DrugovichDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ManagerMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerGroupMap).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql();
            }
        }

        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Manager>? Managers { get; set; }
        public DbSet<CustomerGroup>? CustomerGroups { get; set; }
    }
}
