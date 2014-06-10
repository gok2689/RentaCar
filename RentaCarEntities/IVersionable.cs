using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCarEntities
{
 public  class IVersionable
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Version { get; set; }

    }
}
