using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
   public interface ICarDao : IEntityRepository<Car>
   {
        List<CarDetailDto> GetCarDetails(int carId);

        List<CarDetailDto> GetCarDetails3(Expression<Func<Car, bool>> filter = null);
        List<CarDetailDto> GetCarDetails2();

    }
}
