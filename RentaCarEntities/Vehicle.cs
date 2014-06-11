using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RentaCarEntities
{
  public  class Vehicle : IVersionable
    {   [Required(ErrorMessage="Bir plaka giriniz")]
        public string Plate { get; set; }
        public int BrandId { get; set; }
        [Required(ErrorMessage="Bir model belirtiniz")]
        public string Model { get; set; }
        [Required(ErrorMessage="Bir yakıt tipi belirtiniz")]
        public string FuelType { get; set; }
        public int BranchId { get; set; }
        public decimal PricePerDay { get; set; }

    }
}
