using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarEntities;

namespace RentaCarDal.Abstract
{
  public  interface IMemeber
    {
      List<Memeber> GetAll();
      Memeber Get(int Id);
      void Add(Memeber item);
      void Update(Memeber item);
      void Delete(int Id);
      bool IsLogin(string email, string password);
      bool IsAdmin(int type);
    }
}
