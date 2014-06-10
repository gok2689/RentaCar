using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarEntities;
namespace RentaCarDal.Abstract
{
   public interface IBrand
    {
       List<Brand> GetAll();
       Brand Get(int Id);
       void Add(Brand item);
       void Update(Brand item);
       void Delete(int Id);

    }
}
