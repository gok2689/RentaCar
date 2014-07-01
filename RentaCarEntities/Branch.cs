using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentaCarEntities
{
    public partial class Branch
    {
        public Branch()
        {
            this.Vehicle = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
