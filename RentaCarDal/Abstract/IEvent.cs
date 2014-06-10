using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarEntities;

namespace RentaCarDal.Abstract
{
  public  interface IEvent
    {
      List<Event> GetAll();
      Event Get(int Id);
      void Add(Event item);
      void Update(Event item);
      void Delete(int Id);

    }
}
