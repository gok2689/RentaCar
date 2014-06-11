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
   public class VehicleManager : IVehicle
    {
       VehicleDal _dal = new VehicleDal();
        public List<RentaCarEntities.Vehicle> GetAll()
        {
            return _dal.GetAll();
        }

        public RentaCarEntities.Vehicle Get(int Id)
        {
            return _dal.Get(Id);
        }

        public void Add(RentaCarEntities.Vehicle item)
        {
            _dal.Add(item);
        }

        public void Update(RentaCarEntities.Vehicle item)
        {
            _dal.Update(item);
        }

        public void Delete(int Id)
        {
            _dal.Delete(Id);
        }

        public IQueryable<Filter> Filtre(params string[] parametreler)
        {
            return _dal.Filtre(parametreler);
        }
    }
}
