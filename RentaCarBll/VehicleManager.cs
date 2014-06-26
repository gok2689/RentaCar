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
            BrandManager _brandManager = new BrandManager();
            BranchManager _branchManager = new BranchManager();

            var query = (from v in _dal.GetAll()
                         join b in _brandManager.GetAll() on v.BrandId equals b.Id
                         join br in _branchManager.Getall() on v.BranchId equals br.Id
                         select new Vehicle
                         {
                             _brandName = b.Name,
                             _branchName = br.Name,

                             BranchId = v.BranchId,
                             Event = v.Event,
                             FuelType = v.FuelType,
                             Id = v.Id,
                             IsDeleted = v.IsDeleted,
                             Model = v.Model,
                             Plate = v.Plate,
                             PricePerDay = v.PricePerDay,
                             Version = v.Version

                         }).ToList();
            return query;
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

       
       public List<Vehicle> Filtre(string searchText)
        {
            BrandManager _brandManager=new BrandManager();
            BranchManager _branchManager = new BranchManager();

            var query = (from v in _dal.GetAll()
                         join b in _brandManager.GetAll() on v.BrandId equals b.Id
                         join br in _branchManager.Getall() on v.BranchId equals br.Id
                         select new Vehicle
                         {
                             _brandName = b.Name,
                             _branchName=br.Name,
                             
                             BranchId = v.BranchId,
                             Event = v.Event,
                             FuelType = v.FuelType,
                             Id = v.Id,
                             IsDeleted = v.IsDeleted,
                             Model = v.Model,
                             Plate = v.Plate,
                             PricePerDay = v.PricePerDay,
                             Version = v.Version
                 
                         }).ToList();

            return query.Where(m => m._brandName.Contains(searchText) || m.FuelType.Contains(searchText) || m.Model.Contains(searchText) && m.IsRezerved == false).ToList();

        }
    }
}
