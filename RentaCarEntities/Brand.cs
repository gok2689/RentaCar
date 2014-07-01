using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentaCarEntities
{
    public partial class Brand
    {
        public Brand()
        {
            this.Vehicle = new HashSet<Vehicle>();
            Version = DateTime.Now;
            IsDeleted = false;
        }
        
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime Version { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
