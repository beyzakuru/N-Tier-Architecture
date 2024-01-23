using NTierArchitecture.Core.Models;
using NTierArchitecture.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Repository.Repositories
{
    public class PassportRepository : GenericRepository<Passport>, IPassportRepository
    {
        public PassportRepository(AppDbContext context) : base(context)
        {
        }
    }
}
