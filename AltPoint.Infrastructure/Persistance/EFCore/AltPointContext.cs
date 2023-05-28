using AltPoint.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Infrastructure.Persistance.EFCore
{
    public class AltPointContext : DbContext
    {
        public AltPointContext(DbContextOptions<AltPointContext> options) : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Child> Childs { get; set; } = null!;
        public DbSet<Communication> Communications { get; set; } = null!;
        public DbSet<Job> Jobs { get; set; } = null!;
        public DbSet<Passport> Passports { get; set; } = null!;
        public DbSet<Document> Documents { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Id");
                entity.HasOne(c => c.Passport)
                    .WithOne(p => p.Client)
                    .HasForeignKey<Passport>(p => p.ClientId);
                entity.HasQueryFilter(c => !c.IsDeleted);
            });
        }
    }
}
