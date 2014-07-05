using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentaCarEntities;

namespace RentaCar.Models
{
    public class VehicleModel
    {
        public List<Vehicle> Vehicles { get; set; }
        public Event Events { get; set; }
        public Member Memebers { get; set; }
        public Branch Branchs { get; set; }
        public Brand Brands { get; set; }
        public PagingInfo PagingInfo { get; set; }

    }
}