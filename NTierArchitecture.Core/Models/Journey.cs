using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Core.Models
{
    public class Journey: BaseEntity
    {
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }
        public DateTime JourneyDate { get; set; }

        // Bire çok ilişki için
        public ICollection<Passenger> Passengers { get; set; }
    }
}
