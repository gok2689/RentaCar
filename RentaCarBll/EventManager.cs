using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarDal.Abstract;
using RentaCarDal.Concrete;
using RentaCarEntities;

namespace RentaCarBll
{
  public  class EventManager : IEvent
    {
      EventDal _dal = new EventDal();
      VehicleManager vehiclemanager = new VehicleManager();
      MemberManager MemberManager = new MemberManager();
   
        public List<RentaCarEntities.Event> GetAll()
        {
            var query = (from e in _dal.GetAll()
                         join v in vehiclemanager.GetAll() on e.VehicleId equals v.Id
                         join m in MemberManager.GetAll() on e.MemberId equals m.Id
                         select new Event
                         {
                             _kulEmail = m.Email,
                             _VehicleName = v._brandName,

                             MemberId = e.MemberId,
                             StartDate = e.StartDate,
                             Id = e.Id,
                             IsDeleted = e.IsDeleted,
                             EndDate = e.EndDate,
                             Version = e.Version,
                             VehicleId = e.VehicleId

                         }).ToList();
            return query;
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
