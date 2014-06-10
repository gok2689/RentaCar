using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarDal.Concrete;
using RentaCarDal.Abstract;

namespace RentaCarBll
{
  public  class BranchManager : IBranch
    {
      BranchDal _dal = new BranchDal();
        public List<RentaCarEntities.Branch> Getall()
        {
          return  _dal.Getall();
        }

        public RentaCarEntities.Branch Get(int Id)
        {
          return  _dal.Get(Id);
        }

        public void Add(RentaCarEntities.Branch item)
        {
            _dal.Add(item);
        }

        public void Update(RentaCarEntities.Branch item)
        {
            _dal.Update(item);
        }

        public void Delete(int Id)
        {
            _dal.Delete(Id);
        }
    }
}
