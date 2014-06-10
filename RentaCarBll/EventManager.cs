using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarDal.Abstract;
using RentaCarDal.Concrete;

namespace RentaCarBll
{
  public  class EventManager : IEvent
    {
      EventDal _dal = new EventDal();
        public List<RentaCarEntities.Event> GetAll()
        {
            return _dal.GetAll();
        }

        public RentaCarEntities.Event Get(int Id)
        {
            return _dal.Get(Id);
        }

        public void Add(RentaCarEntities.Event item)
        {
            _dal.Add(item);
        }

        public void Update(RentaCarEntities.Event item)
        {
            _dal.Update(item);
        }

        public void Delete(int Id)
        {
            _dal.Delete(Id);
        }
    }
}
