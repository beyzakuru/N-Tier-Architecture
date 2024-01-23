using NTierArchitecture.Core.DTOs;
using NTierArchitecture.Core.DTOs.Authentication;
using NTierArchitecture.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Core.Services
{
    public interface IPassengerService: IService<Passenger>
    {
        string GeneratePasswordHash(string firstName, string password);

        PassengerDto FindPassenger(string firstName, string password);

        AuthResponseDto Login(AuthRequestDto request); // videondan ekledim

        Passenger SignUp(AuthRequestDto authDto);
    }
}
