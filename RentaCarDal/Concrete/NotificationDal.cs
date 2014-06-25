using RentaCarDal.Abstract;
using RentaCarEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCarDal.Concrete
{
   public class NotificationDal : INotification
    {
       RentaCarContext _context = new RentaCarContext();
        public List<RentaCarEntities.Notification> GetAll()
        {
            return _context.Notifications.ToList();
        }

        public RentaCarEntities.Notification Get(int Id)
        {
            return _context.Notifications.SingleOrDefault(a => a.Id == Id);
        }

        public void Add(RentaCarEntities.Notification item)
        {
            _context.Notifications.Add(item);
            _context.SaveChanges();
        }

        public void Update(RentaCarEntities.Notification item)
        {
            Notification ObjectToUpdate = _context.Notifications.FirstOrDefault(a => a.Id == item.Id);
            ObjectToUpdate.Description = item.Description;
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Notification ObjectToDelete = _context.Notifications.Remove(_context.Notifications.FirstOrDefault(a => a.Id == Id));
            _context.SaveChanges();
        }
    }
}
