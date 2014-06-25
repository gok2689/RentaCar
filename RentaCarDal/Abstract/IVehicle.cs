using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarEntities;

namespace RentaCarDal.Abstract
{
  public  interface IVehicle
    {
      List<Vehicle> GetAll();
      Vehicle Get(int Id);
      void Add(Vehicle item);
      void Update(Vehicle item);
      void Delete(int Id);
  

    }
}
