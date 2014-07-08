using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentaCarEntities
{
    public partial class Event
    {
        public Event()
        {
            Version = DateTime.Now;
            IsDeleted = false;
        }
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime Version { get; set; }
        [Display(Name="Kullanıcı")]
        public int MemberId { get; set; }
        [Display(Name="Araç")]
        public int VehicleId { get; set; }
        
        [Display(Name="Başlangıç tarihi")]
        [DataType(DataType.Date)]
        public System.DateTime StartDate { get; set; }
      
        [Display(Name="Bitiş Tarihi")]
        [DataType(DataType.Date)]

        public System.DateTime EndDate { get; set; }
        [Display(Name="MailAdresi")]
        [NotMapped]
        public string _kulEmail { get; set; }
        [NotMapped]
        [Display(Name="AraçMarkası")]
        public string _VehicleName { get; set; }

       
        
    }

    
}
