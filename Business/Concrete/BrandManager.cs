using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class BrandManager : IBrandService
    {
        private IBrandDao _brandDao;

        public BrandManager(IBrandDao brandDao)
        {
            _brandDao = brandDao;
        }
        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length>2)
            {
                _brandDao.Add(brand);
               return new SuccessResult(Messages.BrandAdded);
            }
            else
            {
               return new ErrorResult(Messages.BrandNameInValid);
            }
        }

        public IResult Delete(Brand brand)
        {
            _brandDao.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>>  GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDao.GetAll()); 
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDao.Get(brand => brand.BrandId == id)); 
        }

        public IResult Update(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _brandDao.Add(brand);
               return new SuccessResult(Messages.BrandAdded);
            }
            else
            {
                Console.WriteLine($"marka ismini 2 harfden fazla giriniz {brand.BrandName}");
                return new ErrorResult(Messages.BrandNameInValid);
            }
        }
    }
}
