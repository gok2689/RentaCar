using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RentaCarEntities
{
  public  class Event : IVersionable
    {
        public int MemberId { get; set; }
        public int VehicleId { get; set; }
        [Required(ErrorMessage="Lütfen bir tarih belirtiniz")]
        [Display(Name="Başlangıç Tarihi")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage="Lütfen bir trih seçiniz")]
        [Display(Name="Bitiş Tarihi")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

    }
}
