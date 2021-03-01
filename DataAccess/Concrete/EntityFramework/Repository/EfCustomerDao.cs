using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repository
{
   public class EfCustomerDao : EfEntityRepositoryBase<Customer,RentCarContext> , ICustomerDao
    {

    }
}
