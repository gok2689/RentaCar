using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarEntities;
using RentaCarDal.Abstract;

namespace RentaCarDal.Concrete
{
   public class EventDal : IEvent
    {
       RentaCarContext context = new RentaCarContext();
        public List<Event> GetAll()
        {
            return context.Events.Where(a => a.IsDeleted == false).ToList();
        }

        public Event Get(int Id)
        {
            return context.Events.SingleOrDefault(a => a.Id == Id && a.IsDeleted == false);
        }

        public void Add(Event item)
        {
            context.Events.Add(item);
            context.SaveChanges();
        }

        public void Update(Event item)
        {
            Event ObjectToUpdate = context.Events.FirstOrDefault(a => a.Id == item.Id && a.IsDeleted == false);
            ObjectToUpdate.MemberId = item.MemberId;
            ObjectToUpdate.MemberId = item.MemberId;
            ObjectToUpdate.Version = item.Version;
            ObjectToUpdate.StartDate = item.StartDate;
            ObjectToUpdate.EndDate = item.EndDate;
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.Events.Remove(context.Events.FirstOrDefault(a => a.Id == Id));
            context.SaveChanges();
        }
    }
}
