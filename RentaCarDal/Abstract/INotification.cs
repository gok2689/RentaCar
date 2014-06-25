using RentaCarEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCarDal.Abstract
{
 public  interface INotification
    {
     List<Notification> GetAll();
     Notification Get(int Id);
     void Add(Notification item);
     void Update(Notification item);
     void Delete(int Id);
    }
}
