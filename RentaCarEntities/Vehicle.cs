using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCarEntities
{
  public  class Vehicle : IVersionable
    {
        public string Plate { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string FuelType { get; set; }
        public int BranchId { get; set; }
        public decimal PricePerDay { get; set; }

    }
}
