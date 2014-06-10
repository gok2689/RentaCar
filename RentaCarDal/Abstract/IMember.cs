using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarEntities;

namespace RentaCarDal.Abstract
{
  public  interface IMember
    {
      List<Member> GetAll();
      Member Get(int Id);
      void Add(Member item);
      void Update(Member item);
      void Delete(int Id);
      bool IsLogin(string email, string password);
      bool IsAdmin(int type);
    }
}
