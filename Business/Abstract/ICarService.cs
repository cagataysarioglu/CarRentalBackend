using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetByDailyPrice(decimal min, decimal max);
        Car GetById(int id);
        List<CarDetailDto> GetProductDetails();
    }
}
