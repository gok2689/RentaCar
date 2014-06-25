using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentaCarEntities
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            this.Event = new HashSet<Event>();
            Version = DateTime.Now;
            IsDeleted = false;
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime Version { get; set; }
        public string Plate { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string FuelType { get; set; }
        public int BranchId { get; set; }
        public decimal PricePerDay { get; set; }

        [NotMapped]
        public string _brandName { get; set; }
        [NotMapped]
        public string _branchName { get; set; }
        public virtual ICollection<Event> Event { get; set; }
    }
}
