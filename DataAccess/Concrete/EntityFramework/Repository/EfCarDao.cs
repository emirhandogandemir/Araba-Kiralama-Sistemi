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


        public List<CarDetailDto> GetCarDetails(int carId)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from car in context.Car
                             join b in context.Brands
                                 on car.BrandId equals b.BrandId
                             join color in context.Colors
                                 on car.ColorId equals color.ColorId
                         
                             where car.CarId ==carId
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Descriptions,
                                 ModelYear = car.ModelYear,
                                 ImagePath = (from carImage in context.CarImages where carImage.CarId == car.CarId select carImage.ImagePath).ToList()

                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetails2()
        {
            
                using (RentCarContext context = new RentCarContext())
                {
                    var result = from car in context.Car
                                 join b in context.Brands
                                     on car.BrandId equals b.BrandId
                                 join color in context.Colors
                                     on car.ColorId equals color.ColorId
                                 //join image in context.CarImages
                                 //on car.CarId equals image.CarId

                                 select new CarDetailDto
                                 {
                                     CarId = car.CarId,
                                     BrandId =b.BrandId,
                                     ColorId=color.ColorId,
                                     CarName = car.CarName,
                                     BrandName = b.BrandName,
                                     ColorName = color.ColorName,
                                     DailyPrice = car.DailyPrice,
                                     Description = car.Descriptions,
                                     ModelYear = car.ModelYear,
                                     ImagePath = (from carImage in context.CarImages where carImage.CarId == car.CarId select carImage.ImagePath).ToList()

                                 };
                    return result.ToList();
                }
            }

        public List<CarDetailDto> GetCarDetails3(Expression<Func<Car, bool>> filter = null)
        {
            using (RentCarContext recapContext = new RentCarContext())
            {
                IQueryable<CarDetailDto> carDetailsDtos = from car in filter is null ? recapContext.Car : recapContext.Car.Where(filter)
                                                               join brand in recapContext.Brands
                                                                   on car.BrandId equals brand.BrandId
                                                               join color in recapContext.Colors
                                                                   on car.ColorId equals color.ColorId
                                                               select new CarDetailDto
                                                               {
                                                                   CarId = car.CarId,
                                                                   BrandId = brand.BrandId,
                                                                   ColorId = color.ColorId,
                                                                   CarName = car.CarName,
                                                                   BrandName = brand.BrandName,
                                                                   ColorName = color.ColorName,
                                                                   DailyPrice = car.DailyPrice,
                                                                   Description = car.Descriptions,
                                                                   ModelYear = car.ModelYear,
                                                                   ImagePath = (from carImage in recapContext.CarImages where carImage.CarId == car.CarId select carImage.ImagePath).ToList()
                                                               };
                return carDetailsDtos.ToList();
            }
        }
    }
}
