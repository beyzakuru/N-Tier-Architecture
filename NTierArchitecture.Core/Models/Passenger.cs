using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Core.Models
{
    public class Passenger: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCNo { get; set; } // unique olmalı.
        //public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string EMail { get; set; }
        public string Telephone { get; set; }
        public string Password { get; set; }

        // 1 - N bir ilişkide Passenger tablosu Journey tablosuna bağlı olduğunda Passenger tarafında bunu belirtmek için Foreign Key oluşturmamız gerek. 

        // İlişkilendirme Kısmı

        // Foreign Key
        public int JourneyId { get; set; }
        public Journey Journey { get; set; }
    }
}
