using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarDal.Abstract;
using RentaCarEntities;

namespace RentaCarDal.Concrete
{
   public class MemberDal : IMember
    {
       RentaCarContext context = new RentaCarContext();
        public List<Member> GetAll()
        {
            return context.Members.Where(a => a.IsDeleted == false).ToList();
        }

        public Member Get(int Id)
        {
            return context.Members.SingleOrDefault(a => a.Id == Id && a.IsDeleted == false);
        }

        public void Add(Member item)
        {
            context.Members.Add(item);
            context.SaveChanges();
        }

        public void Update(Member item)
        {
            Member MemberToUpdate = context.Members.FirstOrDefault(a => a.Id == item.Id && a.IsDeleted == false);
           
            MemberToUpdate.NameSurName = item.NameSurName;
            MemberToUpdate.Password = item.Password;
            MemberToUpdate.Type = item.Type;
            MemberToUpdate.Version = item.Version;
            MemberToUpdate.Email = item.Email;
        }

        public void Delete(int Id)
        {
            context.Members.Remove(context.Members.FirstOrDefault(a => a.Id == Id));
            context.SaveChanges();
        }

        public bool IsLogin(string email, string password)
        {
            return context.Members.Any(a => a.Email == email && a.Password == password);
        }

        public bool IsAdmin(int type)
        {
            return context.Members.Any(a => a.Type == type);
        }
    }
}
