using NTierArchitecture.Core.Models;
using NTierArchitecture.Core.Repositories;
using NTierArchitecture.Core.Services;
using NTierArchitecture.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Service.Services
{
    public class PassportService : Service<Passport>, IPassportService
    {
        public PassportService(IGenericRepository<Passport> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
