using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RentaCarEntities
{
    public partial class Brand
    {
        public Brand()
        {
            this.Vehicle = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime Version { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
