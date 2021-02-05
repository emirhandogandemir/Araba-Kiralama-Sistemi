using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Business.Abstract;
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
        public void Add(Brand brand)
        {
            if (brand.BrandName.Length>2)
            {
                _brandDao.Add(brand);
                Console.WriteLine(brand.BrandName + " Markası başarı ile eklendi");
            }
            else
            {
                Console.WriteLine($"marka ismini 2 harfden fazla giriniz {brand.BrandName}");
            }
        }

        public void Delete(Brand brand)
        {
            _brandDao.Delete(brand);
            Console.WriteLine(brand.BrandName +"Markası başarı ile silindi");
        }

        public List<Brand> GetAll()
        {
            return _brandDao.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDao.Get(brand => brand.BrandId == id);
        }

        public void Update(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _brandDao.Add(brand);
                Console.WriteLine(brand.BrandName + " Markası başarı ile eklendi");
            }
            else
            {
                Console.WriteLine($"marka ismini 2 harfden fazla giriniz {brand.BrandName}");
            }
        }
    }
}
