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
    public class PassportConfiguration : IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // PK'nın 1'er 1'er artması
            builder.Property(x => x.Id).UseIdentityColumn();

            // PassportNo'nun unique olarak tanımması
            builder.HasIndex(x => x.Id).IsUnique();

            // PassportNo 10 haneli olsun
            builder.Property(x => x.PassportNo).HasMaxLength(10);

            // Tablo ismi belirleme
            builder.ToTable("Passports");
        }
    }
}
