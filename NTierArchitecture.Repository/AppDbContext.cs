using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Repository
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Journey> Journeys { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Passport> Passports { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Modified:
                            {
                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Modified:
                            {
                                // createdDate veritabanından çekiliğ yansıtılmalı.
                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate = DateTime.Now;
                                entityReference.UpdatedDate = null;
                                break;
                            }
                        case EntityState.Deleted:
                            {
                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }

                    }
                }
            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Örnek journey ve passenger arasında foreign key tanımlama
            /* Biz ayrı bir konfigürasyon dosyası oluşturarak aşağıda çağırdık.
            modelBuilder.Entity<Journey>()
                .HasMany(t => t.Passengers)
                .WithOne(u => u.Journey)
                .HasForeignKey(u => u.JourneyId);
            */

            // Konfigürasyon dosyalarını çağırmak için önerilmeyen yöntem
            /*
            modelBuilder.ApplyConfiguration(new JourneyConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            modelBuilder.ApplyConfiguration(new PassportConfiguration());
            */

            // ***Önerilen Çözüm***
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
