using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RentaCarEntities
{
    public partial class Event
    {
        public Event()
        {
            Version = DateTime.Now;
            IsDeleted = false;
        }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime Version { get; set; }
        public int MemberId { get; set; }
        public int VehicleId { get; set; }
        [DataType(DataType.DateTime)]
        public System.DateTime StartDate { get; set; }
        [DataType(DataType.DateTime)]
        public System.DateTime EndDate { get; set; }

        public virtual Member Member { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }

    
}
