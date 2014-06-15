using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarDal.Concrete;
using RentaCarDal.Abstract;
using RentaCarEntities;
using RentaCar.Models;


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
            if (item == null) throw new ArgumentNullException("item");
            _dal.Add(item);
        }

        public void Update(RentaCarEntities.Member item)
        {
            if (item == null) throw new ArgumentNullException("item");
            _dal.Update(item);
        }

        public void Delete(int Id)
        {
            _dal.Delete(Id);
        }

        public bool IsLogin(string email, string password)
        {
            if (email == null) throw new ArgumentNullException("email");
            if (password == null) throw new ArgumentNullException("password");
            return _dal.IsLogin(email, password);
        }

        public bool IsAdmin(int type)
        {
            if (type==1)
            {
                this.Equals(RentaCar.Models.Enums.UserTypes.Admin);
            }
            else
            {
                this.Equals(RentaCar.Models.Enums.UserTypes.User);
            }
            return _dal.IsAdmin(type);

            
        }
       
    }
}
