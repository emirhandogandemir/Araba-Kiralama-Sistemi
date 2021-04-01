using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework.Repository
{
    public class EfRentalDao : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDao
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                    join c in context.Car
                        on r.CarId equals c.CarId
                    join cu in context.Customers
                        on r.CustomerId equals cu.CustomerId
                    join b in context.Brands
                        on c.BrandId equals b.BrandId
                    join u in context.Users
                        on cu.UserId equals u.UserId
                    select new RentalDetailDto
                    {
                        RentalId = r.RentalId,
                        CarName = c.CarName,
                        CompanyName = cu.CompanyName,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate,
                        CarId= c.CarId,
                        CustomerId = cu.CustomerId,
                        BrandName = b.BrandName,
                        FirstName = cu.FirstName,
                        LastName =cu.LastName,

                    };
                return result.ToList();
            }
        }
    }
}
