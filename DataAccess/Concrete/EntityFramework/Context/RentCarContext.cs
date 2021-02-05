using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DataAccess.Concrete.EntityFramework
{
   public class RentCarContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=EMIRHANDGNDMR;Database=RentACar; Trusted_Connection = true");
        }

        private DbSet<Car> Car { get; set; }
        private DbSet<Color> Colors { get; set; }

        private DbSet<Brand> Brands { get; set; }
    }
}
