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

        public List<Vehicle> Filter(string fueltype, string model, int brandId)
        {
          //return context.Vehicles.SqlQuery("Select * from vehicle v ")
        }
    }
}
