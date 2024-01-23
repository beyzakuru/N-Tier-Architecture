using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Core.DTOs
{
    public class NoContentDto
    {
        public int StatusCode {  get; set; }
        public List<string> Errors { get; set; }
    }
}
