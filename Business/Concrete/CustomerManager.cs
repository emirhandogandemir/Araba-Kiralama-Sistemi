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
   public class CustomerManager : ICustomerService
    {
        private ICustomerDao _customerDao;

        public CustomerManager(ICustomerDao customerDao)
        {
            _customerDao = customerDao;
        }
        public IResult Add(Customer customer)
        {
            _customerDao.Add(customer);
            return new SuccessResult(Messages.AddedCustomer);
        }

        public IResult Delete(Customer customer)
        {
           _customerDao.Delete(customer);
           return new SuccessResult(Messages.DeletedCustomer);
        }

        public IDataResult<List<Customer>> GetAll()
        {
           return new SuccessDataResult<List<Customer>>(_customerDao.GetAll());
        }

        public IDataResult<Customer> GetById(int id)
        {
           return new SuccessDataResult<Customer>(_customerDao.Get(ı=>ı.CustomerId==id));
        }

        public IResult Update(Customer customer)
        {
           _customerDao.Update(customer);
           return  new SuccessResult(Messages.UpdatedCustomer);
        }
    }
}
