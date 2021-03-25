using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Transaction;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDao _carDao;

        public CarManager(ICarDao carDao)
        {
            _carDao = carDao;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDao.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if(car.DailyPrice<10)
            {
                throw new Exception("");
            }
            Add(car);

            return null;
        }

        public IResult Delete(Car car)
        {
          _carDao.Delete(car);
         return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDao.GetAll(), Messages.CarsListed); ;
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return  new SuccessDataResult<List<Car>>(_carDao.GetAll(brand => brand.BrandId == id)) ;
        }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDao.GetAll(color => color.ColorId == id)); ;
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDao.GetAll(car => car.DailyPrice >= min && car.DailyPrice <= max)); ;
        }

        [CacheAspect]
        public IDataResult<Car>  GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDao.Get(car => car.CarId == id)); ;
        }

        public IDataResult<List<Car>> GetByModelYear(string year)
        {
            return new SuccessDataResult<List<Car>>(_carDao.GetAll(car => car.ModelYear.Contains(year) == true)); ;
        }

     

        public IDataResult<List<CarDetailDto>> GetCarDetails(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDao.GetCarDetails(carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails2()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDao.GetCarDetails2());
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDao.Update(car);
               return new SuccessResult(Messages.CarUpdated);
            }
            else
            {
                Console.WriteLine($"araba güncelleme aşamasında günlük fiyat hatalı girildi . O dan büyük giriniz girdiginiz deger {car.DailyPrice}");
                return new ErrorResult(Messages.CarPriceInValid);
            }
        }

       
        
    }
}
