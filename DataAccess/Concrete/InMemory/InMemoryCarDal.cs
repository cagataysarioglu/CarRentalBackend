using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, ColorId = 7, Name = "TOGG", ModelYear = 2022, DailyPrice = 640, Description = "Hibrit otomatik"},
                new Car{Id = 2, BrandId = 4, ColorId = 3, Name = "BMW", ModelYear = 2020, DailyPrice = 600, Description = "Dizel otomatik"},
                new Car{Id = 3, BrandId = 3, ColorId = 2, Name = "VW", ModelYear = 2021, DailyPrice = 570, Description = "Benzinli manuel"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = null;
            carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return _cars.SingleOrDefault(filter.Compile());
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return filter == null ? _cars.ToList() : _cars.Where(filter.Compile()).ToList();
        }

        public List<Car> GetCarsByBrandId(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarsByColorId(Expression<Func<Car, bool>> filter)
        {
            return null;
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
