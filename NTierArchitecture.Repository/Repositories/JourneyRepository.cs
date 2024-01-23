using NTierArchitecture.Core.Models;
using NTierArchitecture.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Repository.Repositories
{
    public class JourneyRepository : GenericRepository<Journey>, IJourneyRepository
    {
        public JourneyRepository(AppDbContext context) : base(context)
        {
        }
    }
}
