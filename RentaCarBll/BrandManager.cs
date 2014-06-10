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
   public class BrandManager : IBrand
    {
       BrandDal _dal = new BrandDal();

        public List<Brand> GetAll()
        {
            return _dal.GetAll();
        }

        public Brand Get(int Id)
        {
            return _dal.Get(Id);
        }

        public void Add(Brand item)
        {
            _dal.Add(item);
        }

        public void Update(Brand item)
        {
            _dal.Update(item);
        }

        public void Delete(int Id)
        {
            _dal.Delete(Id);
        }
    }
}
