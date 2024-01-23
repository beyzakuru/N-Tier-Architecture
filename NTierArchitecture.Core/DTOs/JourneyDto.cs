using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Core.DTOs
{
    public class JourneyDto: BaseDto
    {
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }
        public DateTime JourneyDate { get; set; }
    }
}
