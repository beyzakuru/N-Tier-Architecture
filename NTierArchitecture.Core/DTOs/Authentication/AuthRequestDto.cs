using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Core.DTOs.Authentication
{
    public class AuthRequestDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
    }
}
