using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierArchitecture.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Repository.Seeds
{
    public class PassportSeed : IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> builder)
        {
            builder.HasData(
               new Passport
               {
                   Id = 1,
                   PassportNo = "U111111111",
                   ExpiryDate = new DateTime(2025, 01, 23, 12, 36, 00),
                   PassengerId = 1,
                   JourneyId = 1
               },
               new Passport
               {
                   Id = 2,
                   PassportNo = "U222222222",
                   ExpiryDate = new DateTime(2025, 02, 13, 13, 42, 00),
                   PassengerId = 2,
                   JourneyId = 2
               },
               new Passport
               {
                   Id = 3,
                   PassportNo = "U333333333",
                   ExpiryDate = new DateTime(2025, 03, 11, 16, 12, 00),
                   PassengerId = 3,
                   JourneyId = 3
               },
               new Passport
               {
                   Id = 4,
                   PassportNo = "U444444444",
                   ExpiryDate = new DateTime(2025, 04, 02, 08, 50, 00),
                   PassengerId = 4,
                   JourneyId = 4
               }
               );
        }
    }
}
