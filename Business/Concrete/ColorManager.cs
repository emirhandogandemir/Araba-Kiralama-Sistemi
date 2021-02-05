using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDao _colorDao;

        public ColorManager(IColorDao colorDao)
        {
            _colorDao = colorDao;
        }
        public void Add(Color color)
        {
           _colorDao.Add(color);
           Console.WriteLine(color.ColorName+" rengi başarı ile eklenmiştir");
        }

        public void Delete(Color color)
        {
           _colorDao.Delete(color);
           Console.WriteLine(color.ColorName + "rengi başarı ile silinmiştir");
        }

        public List<Color> GetAll()
        {
            return _colorDao.GetAll();
        }

        public Color GetById(int id)
        {
            return _colorDao.Get(color => color.ColorId == id);
        }

        public void Update(Color color)
        {
           _colorDao.Update(color);
           Console.WriteLine(color.ColorName +" rengi başarı ile güncellenmiştir");
        }
    }
}
