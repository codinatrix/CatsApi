using Cats.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cats.Infrastructure
{
    public class CatApiContext : DbContext
    {
        public CatApiContext()
        {

        }

        public CatApiContext(DbContextOptions<CatApiContext> options)
            : base(options)
        {
        }

        public DbSet<Cat> Cats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>();
        }
    }
}
