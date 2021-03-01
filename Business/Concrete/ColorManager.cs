using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
        public IResult Add(Color color)
        {
           _colorDao.Add(color);
         return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
           _colorDao.Delete(color);
          return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDao.GetAll()); 
        }

        public IDataResult<Color>  GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDao.Get(color => color.ColorId == id)); ;
        }

        public IResult Update(Color color)
        {
           _colorDao.Update(color);
          return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
