using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Core.Models
{
    public class Passport
    {
        public int Id { get; set; }
        public string PassportNo { get; set; } // unique olmalı.
        public DateTime ExpiryDate { get; set; }

        // Foreign Key
        public int PassengerId { get; set; }
        public int JourneyId { get; set; }

        // Bire bir ilişki için
        public Passenger Passenger { get; set; }
    }
}
