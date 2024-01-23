using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using NTierArchitecture.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Repository.Configurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Primary Key'in 1'er 1'er artması için
            builder.Property(x => x.Id)
                .UseIdentityColumn();

            // TC kimlik numarasını unique olarak tanımlamak
            builder.HasIndex(x => x.TCNo)
                .IsUnique();
            

            // TC kimlik numarası max 11 haneli olsun.
            builder.Property(x => x.TCNo).HasMaxLength(11);

            // Alanların zorunnlu olması ve maksimum uzunluklarının tanımlanması
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.EMail).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Telephone).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(200);

            // Tablo ismi belirleme
            builder.ToTable("Passengers");
        }
    }
}
