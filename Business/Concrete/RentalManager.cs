using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDao _rentalDao;

        public RentalManager(IRentalDao rentalDao)
        {
            _rentalDao = rentalDao;
        }
        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate == null && _rentalDao.GetRentalDetails(ı => ı.CarId == rental.CarId).Count > 0)
            {
                return new ErrorResult(Messages.FailedRentalAddOrUpdate);
            }
            _rentalDao.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDao.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
           return new SuccessDataResult<List<Rental>>(_rentalDao.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
           return new SuccessDataResult<Rental>(_rentalDao.Get(I=>I.RentalId==id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
          return new SuccessDataResult<List<RentalDetailDto>>(_rentalDao.GetRentalDetails(filter),Messages.RentalReturned);
        }

        public IResult Update(Rental rental)
        {
          _rentalDao.Update(rental);
          return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
