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
            IsRezerved = false;
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime Version { get; set; }
        [Display(Name="Plaka")]
        public string Plate { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        [Display(Name="Yakıt tipi")]
        public string FuelType { get; set; }
        public int BranchId { get; set; }
        [Display(Name="Günlük kiralama bedeli")]
        public decimal PricePerDay { get; set; }

        [NotMapped]
        [Display(Name="Marka")]
        public string _brandName { get; set; }
        [NotMapped]
        [Display(Name="Şube")]
        public string _branchName { get; set; }
        public bool IsRezerved { get; set; }
        public virtual ICollection<Event> Event { get; set; }
    }
}
