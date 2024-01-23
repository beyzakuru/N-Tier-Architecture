using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierArchitecture.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Repository.Configurations
{
    public class JourneyConfiguration : IEntityTypeConfiguration<Journey>
    {
        public void Configure(EntityTypeBuilder<Journey> builder)
        {
            // Fluent API Ayarlamaları 

            // Primary Key ayarlaması
            builder.HasKey(t => t.Id);

            // Primary Key otomatik olarak 1'er 1'er artsın.
            builder.Property(t => t.Id)
                .UseIdentityColumn();

            // DepartureLocation alanı için maksimum uzunluğu belirleme ve bu alanı zorunlu hale getiirme
            builder.Property(t => t.DepartureLocation)
                .HasMaxLength(30)
                .IsRequired();

            // ArrivalLocation alanı için maksimum uzunluğu belirleme ve bu alanı zorunlu hale getirme
            builder.Property(t => t.ArrivalLocation)
                .HasMaxLength(30)
                .IsRequired();

            // Tablo ismi belirleme (opsiyonel)
            builder.ToTable("Journeys");
        }
    }
}
