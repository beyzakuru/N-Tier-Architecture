using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Core.Models
{
    public abstract class BaseEntity
    {
        //Id şeklindeki tanımlamalarda EF Core Id property'sinin primary key olduğunu algılıyor.

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
