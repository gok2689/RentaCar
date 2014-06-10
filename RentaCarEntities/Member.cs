using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCarEntities
{
   public class Member : IVersionable
    {
        public string NameSurName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Type { get; set; }

    }
}
