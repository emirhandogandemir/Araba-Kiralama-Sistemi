using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Serialization;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface ICarService
   {
       void Add(Car car);
       void update(Car car);
       void Delete(Car car);
       List<Car> GetAll();
       Car GetById(int id);
       List<Car> GetAllByColorId(int id);
       List<Car> GetAllByBrandId(int id);
       List<Car> GetByDailyPrice(decimal min, decimal max);
       List<Car> GetByModelYear(string year);
    }
}
