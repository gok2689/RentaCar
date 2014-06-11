using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RentaCarEntities
{
  public  class Brand : IVersionable
    {   [Required(ErrorMessage="Lütfen bir marka seçiniz")]
        public string Name { get; set; }
    }
}
