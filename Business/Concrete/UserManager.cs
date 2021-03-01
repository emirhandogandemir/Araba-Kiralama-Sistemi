using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDao _userDao;

        public UserManager(IUserDao userDao)
        {
            _userDao = userDao;
        }
        public IResult Add(User user)
        {
           _userDao.Add(user);
           return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
           _userDao.Delete(user);
           return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
          return new SuccessDataResult<List<User>>(_userDao.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
           return new SuccessDataResult<User>(_userDao.Get(ı=>ı.UserId==id));
        }


        public User GetByMail(string email)
        {
            return _userDao.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDao.GetClaims(user);
        }

        public IResult Update(User user)
        {
          _userDao.Update(user);
          return new SuccessResult(Messages.UserUpdated);
        }

       
    }
}
