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
    public class JourneySeed : IEntityTypeConfiguration<Journey>
    {
        public void Configure(EntityTypeBuilder<Journey> builder)
        {
            builder.HasData(
                new Journey
                {
                    Id = 1,
                    DepartureLocation = "İstanbul",
                    ArrivalLocation = "Ankara",
                    JourneyDate = new DateTime(2024, 01, 12, 9, 30, 0),
                    CreatedDate = DateTime.Now
                },
                 new Journey
                 {
                     Id = 2,
                     DepartureLocation = "Antalya",
                     ArrivalLocation = "Trabzon",
                     JourneyDate = new DateTime(2024, 01, 15, 13, 45, 0),
                     CreatedDate = DateTime.Now
                 },
                  new Journey
                  {
                      Id = 3,
                      DepartureLocation = "Rize",
                      ArrivalLocation = "Muğla",
                      JourneyDate = new DateTime(2024, 01, 20, 15, 00, 0),
                      CreatedDate = DateTime.Now
                  },
                  new Journey
                  {
                      Id = 4,
                      DepartureLocation = "Ankara",
                      ArrivalLocation = "Çanakkale",
                      JourneyDate = new DateTime(2024, 01, 23, 23, 15, 0),
                      CreatedDate = DateTime.Now
                  }
                );
        }
    }
}
