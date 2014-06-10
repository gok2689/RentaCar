using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarEntities;
using RentaCarDal.Abstract;

namespace RentaCarDal.Concrete
{
   public class VehicleDal : IVehicle
    {
       RentaCarContext context = new RentaCarContext();

        public List<Vehicle> GetAll()
        {
            return context.Vehicles.Where(a => a.IsDeleted == false).ToList();
        }

        public Vehicle Get(int Id)
        {
            return context.Vehicles.SingleOrDefault(a => a.Id == Id && a.IsDeleted == false);
        }

        public void Add(Vehicle item)
        {
            context.Vehicles.Add(item);
            context.SaveChanges();
        }

        public void Update(Vehicle item)
        {
            Vehicle ObjectToUpdate = context.Vehicles.FirstOrDefault(a => a.Id == item.Id && a.IsDeleted == false);
            
            ObjectToUpdate.Model = item.Model;
            ObjectToUpdate.Plate = item.Plate;
            ObjectToUpdate.PricePerDay = item.PricePerDay;
            ObjectToUpdate.Version = item.Version;
            ObjectToUpdate.BrandId = item.BrandId;
            ObjectToUpdate.BranchId = item.BranchId;

            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.Vehicles.Remove(context.Vehicles.FirstOrDefault(a => a.Id == Id));
            context.SaveChanges();
        }

      


        public IQueryable<Filter> Filtre (params string[] parametreler)
        {
           var query = ( (from v in context.Vehicles
                         join b in context.Brands on v.BrandId equals b.Id
                         where parametreler.Contains(v.FuelType) & parametreler.Contains(v.Model) & parametreler.Contains(b.Name)
                         select new Filter()
                         {
                             Brand = b.Name,
                             Model = v.Model,
                             FuelType = v.FuelType
                         }));
           return query;
        }
    }
}
