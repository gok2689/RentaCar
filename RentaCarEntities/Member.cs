using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RentaCarEntities
{
   
   public partial class Member
    {
        public Member()
        {
            this.Event = new HashSet<Event>();
        }
    
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime Version { get; set; }
        public string NameSurName { get; set; }
       [Required(ErrorMessage="Lütfen bir şifre giriniz")]
        public string Password { get; set; }
       [Required(ErrorMessage="Lütfen bir email giriniz")]
       [EmailAddress]
        public string Email { get; set; }
        public int Type { get; set; }
    
        public virtual ICollection<Event> Event { get; set; }
    }
}
