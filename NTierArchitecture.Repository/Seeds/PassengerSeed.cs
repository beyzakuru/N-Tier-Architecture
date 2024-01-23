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
    public class PassengerSeed : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.HasData(
                new Passenger
                {
                    Id = 1,
                    FirstName = "Beyza",
                    LastName = "Kuru",
                    TCNo = "11111111111",
                    //BirthDate = new DateTime(2000, 03, 07),
                    Gender = "Kadın",
                    EMail = "beyzakuru@hotmail.com",
                    Telephone = "05363453435",
                    Password = "hello61",
                    CreatedDate = DateTime.Now,
                    JourneyId = 1
                },
                 new Passenger
                 {
                     Id = 2,
                     FirstName = "Bahadır",
                     LastName = "Çetin",
                     TCNo = "22222222222",
                     //BirthDate = new DateTime(2006, 04, 15),
                     Gender = "Erkek",
                     EMail = "bahadircetin@hotmail.com",
                     Telephone = "05443903930",
                     Password = "gymgyme",
                     CreatedDate = DateTime.Now,
                     JourneyId = 2
                 },
                  new Passenger
                  {
                      Id = 3,
                      FirstName = "Sıla",
                      LastName = "Güven",
                      TCNo = "33333333333",
                      //BirthDate = new DateOnly(2000, 07, 10),
                      Gender = "Kadın",
                      EMail = "silaguven@hotmail.com",
                      Telephone = "05438828882",
                      Password = "beauty",
                      CreatedDate = DateTime.Now,
                      JourneyId = 3
                  },
                   new Passenger
                   {
                       Id = 4,
                       FirstName = "Can",
                       LastName = "Tetik",
                       TCNo = "44444444444",
                       //BirthDate = new DateOnly(2000, 08, 23),
                       Gender = "Erkek",
                       EMail = "cantetik@hotmail.com",
                       Telephone = "05374634643",
                       Password = "joker",
                       CreatedDate = DateTime.Now,
                       JourneyId = 4
                   }
                );
        }
    }
}
