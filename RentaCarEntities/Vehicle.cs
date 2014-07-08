﻿using System;
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
           
            Version = DateTime.Now;
            IsDeleted = false;
            
        }
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime Version { get; set; }
        [Display(Name="Plaka")]
        public string Plate { get; set; }
        [Display(Name="Marka")]
        public int BrandId { get; set; }
        public string Model { get; set; }
        [Display(Name="Yakıt tipi")]
        public string FuelType { get; set; }
        [Display(Name="Şube")]
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
        
    }
}
