﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarEntities;
using RentaCarDal.Abstract;

namespace RentaCarDal.Concrete
{
  public  class BranchDal : IBranch
    {
      RentaCarContext context = new RentaCarContext();
        public List<Branch> Getall()
        {
            return context.Branchs.Where(a => a.IsDeleted == false).ToList();
        }

        public Branch Get(int Id)
        {
            return context.Branchs.FirstOrDefault(a => a.IsDeleted == false && a.Id == Id);
        }

        public void Add(Branch item)
        {
            context.Branchs.Add(item);
            context.SaveChanges();
        }

        public void Update(Branch item)
        {
            Branch ObjectToUpdate = context.Branchs.FirstOrDefault(a => a.Id == item.Id && a.IsDeleted == false);
            ObjectToUpdate.Name = item.Name;
            ObjectToUpdate.Code = item.Code;
            ObjectToUpdate.Version = item.Version;
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.Branchs.Remove(context.Branchs.FirstOrDefault(a => a.Id == Id));
            context.SaveChanges();
        }
    }
}
