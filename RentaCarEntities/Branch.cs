using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RentaCarEntities
{
  public  class Branch : IVersionable
    {   [Required(ErrorMessage="Bir şube adı belirtiniz")]
        public string Name { get; set; }
        [Required(ErrorMessage="Şube kodu gerekli")]
        public string Code { get; set; }

    }
}
