using NTierArchitecture.Core.Models;
using NTierArchitecture.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Repository.Repositories
{
    public class PassengerRepository : GenericRepository<Passenger>, IPassengerRepository
    {
        public PassengerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
