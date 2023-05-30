using AltPoint.Domain.Common;
using AltPoint.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
            SavingChanges += AltPointContext_SavingChanges!;
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
            modelBuilder.Entity<Client>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Address>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Job>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Passport>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Document>().HasQueryFilter(c => !c.IsDeleted);

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Id");
                entity.HasOne(c => c.Passport)
                    .WithOne(p => p.Client)
                    .HasForeignKey<Passport>(p => p.ClientId);
                entity.HasOne(c => c.Spouse)
                   .WithOne()
                   .HasForeignKey<Client>(s => s.SpouseId).IsRequired(false)
                   .OnDelete(DeleteBehavior.SetNull);
            });
        }
        private void AltPointContext_SavingChanges(object sender, SaveChangesEventArgs e) 
        {
            var objectContext = (AltPointContext)sender;

            var modifiedEntities = objectContext.ChangeTracker.Entries()
                .Where(c => c.State is EntityState.Added or EntityState.Modified or EntityState.Deleted);

            foreach (var entry in modifiedEntities)
            {
                if (entry.Entity is AuditableEntity auditableEntity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditableEntity.CreateAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            auditableEntity.UpdatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Deleted:
                            auditableEntity.DeletedAt = DateTime.UtcNow;
                            auditableEntity.IsDeleted = true;
                            entry.State = EntityState.Modified;
                            break;
                    }
                }
            }
        }
    }
}
