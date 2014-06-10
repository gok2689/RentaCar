using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarEntities;
using RentaCarDal.Abstract;

namespace RentaCarDal.Concrete
{
  public  class BrandDal : IBrand
    {
      RentaCarContext context = new RentaCarContext();
        public List<Brand> GetAll()
        {
            return context.Brands.Where(a => a.IsDeleted == false).ToList();
        }

        public Brand Get(int Id)
        {
            return context.Brands.FirstOrDefault(a => a.IsDeleted == false && a.Id == Id);
        }

        public void Add(Brand item)
        {
            context.Brands.Add(item);
            context.SaveChanges();
        }

        public void Update(Brand item)
        {
            Brand BrandToUpdate = context.Brands.FirstOrDefault(a => a.Id == item.Id && a.IsDeleted == false);
           
            BrandToUpdate.Name = item.Name;
            BrandToUpdate.Version = item.Version;
            context.SaveChanges();

        }

        public void Delete(int Id)
        {
            context.Brands.Remove(context.Brands.FirstOrDefault(a => a.Id == Id));
            context.SaveChanges();
        }
    }
}
