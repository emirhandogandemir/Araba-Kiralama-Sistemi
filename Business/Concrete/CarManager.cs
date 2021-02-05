using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDao _carDao;

        public CarManager(ICarDao carDao)
        {
            _carDao = carDao;
        }
        public void Add(Car car)
        {
            if (car.DailyPrice>0)
            {
                _carDao.Add(car);
                Console.WriteLine(car.Descriptions + " başarı ile eklendi");
            }
            else
            {
                Console.WriteLine( "günlük fiyatınız 0 dan büyük olmalıdır sisteme girilen deger : {car.DailyPrice}" );
            }
           
        }

        public void Delete(Car car)
        {
          _carDao.Delete(car);
          Console.WriteLine(car.Descriptions + "başarı ile silindi");
        }

        public List<Car> GetAll()
        {
            return _carDao.GetAll();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _carDao.GetAll(brand => brand.BrandId == id);
        }

        public List<Car> GetAllByColorId(int id)
        {
            return _carDao.GetAll(color => color.ColorId == id);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDao.GetAll(car => car.DailyPrice >= min && car.DailyPrice <= max);
        }

        public Car GetById(int id)
        {
            return _carDao.Get(car => car.CarId == id);
        }

        public List<Car> GetByModelYear(string year)
        {
            return _carDao.GetAll(car => car.ModelYear.Contains(year) == true);
        }

        public void update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDao.Update(car);
                Console.WriteLine(car.DailyPrice + " başarı ile güncellendi");
            }
            else
            {
                Console.WriteLine($"araba güncelleme aşamasında günlük fiyat hatalı girildi . O dan büyük giriniz girdiginiz deger {car.DailyPrice}");
            }
        }
    }
}
