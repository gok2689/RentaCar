using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarEntities;

namespace RentaCarDal.Abstract
{
  public  interface IBranch
    {
      List<Branch> Getall();
      Branch Get(int Id);
      void Add(Branch item);
      void Update(Branch item);
      void Delete(int Id);

    }
}
