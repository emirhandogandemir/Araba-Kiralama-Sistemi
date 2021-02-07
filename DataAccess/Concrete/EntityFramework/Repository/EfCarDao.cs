using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repository
{
    public class EfCarDao : EfEntityRepositoryBase<Car, RentCarContext>, ICarDao
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from car in context.Car
                    join b in context.Brands
                        on car.BrandId equals b.BrandId
                    join color in context.Colors
                        on car.ColorId equals color.ColorId
                    select new CarDetailDto
                    {
                        CarName = car.CarName,
                        BrandName = b.BrandName,
                        ColorName = color.ColorName,
                        DailyPrice = car.DailyPrice,

                    };
                return result.ToList();
            }
        }
    }
}
