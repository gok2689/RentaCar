using RentaCarDal.Abstract;
using RentaCarDal.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCarBll
{
  public  class NotificationManager : INotification
    {
      NotificationDal _dal = new NotificationDal();
        public List<RentaCarEntities.Notification> GetAll()
        {
            return _dal.GetAll();
        }

        public RentaCarEntities.Notification Get(int Id)
        {
            return _dal.Get(Id);
        }

        public void Add(RentaCarEntities.Notification item)
        {
            _dal.Add(item);
        }

        public void Update(RentaCarEntities.Notification item)
        {
            _dal.Update(item);
        }

        public void Delete(int Id)
        {
            _dal.Delete(Id);
        }
    }
}
