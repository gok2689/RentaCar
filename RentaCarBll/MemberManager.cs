using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarDal.Concrete;
using RentaCarDal.Abstract;

namespace RentaCarBll
{
   public class MemberManager : IMember
    {
       MemberDal _dal = new MemberDal();
        public List<RentaCarEntities.Member> GetAll()
        {
            return _dal.GetAll();
        }

        public RentaCarEntities.Member Get(int Id)
        {
            return _dal.Get(Id);
        }

        public void Add(RentaCarEntities.Member item)
        {
            _dal.Add(item);
        }

        public void Update(RentaCarEntities.Member item)
        {
            _dal.Update(item);
        }

        public void Delete(int Id)
        {
            _dal.Delete(Id);
        }

        public bool IsLogin(string email, string password)
        {
            return _dal.IsLogin(email, password);
        }

        public bool IsAdmin(int type)
        {
            return _dal.IsAdmin(type);
        }
    }
}
