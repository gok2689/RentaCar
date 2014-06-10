using RentaCarEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCarDal.Concrete
{
   public class RentaCarContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().ToTable("Brand");
            modelBuilder.Entity<Branch>().ToTable("Branch");
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
        }
    }

}
