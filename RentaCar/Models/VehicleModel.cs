using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentaCarEntities;

namespace RentaCar.Models
{
    public class VehicleModel
    {
        public Vehicle Vehicles { get; set; }
        public Event Events { get; set; }
        public PagingInfo PagingInfo { get; set; }

    }
}