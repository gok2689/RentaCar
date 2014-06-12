using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RentaCarEntities
{
   public class Member : IVersionable
    {  
        [Display(Name="İsimSoyisim")]
        
        public string NameSurName { get; set; }
        [Required(ErrorMessage="Bir şifre giriniz")]
        [Display(Name="Şifre")]

        public string Password { get; set; }
        [Required(ErrorMessage="Bir email adressi giriniz ")]
        [Display(Name="Email")]
        [EmailAddress]
       
        public string Email { get; set; }
        public int Type { get; set; }

    }
}
