using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

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

        public Car Get(Func<Car, bool> filter)
        {
            return _cars.SingleOrDefault(filter);
        }

        public List<Car> GetAll(Func<Car, bool> filter = null)
        {
            return filter == null ? _cars.ToList() : _cars.Where(filter).ToList();
        }

        public List<CarDetailDto> GetCarDetails(Func<Car, bool> filter = null)
        {
            return null;
        }

        public List<Car> GetCarsByBrandId(Func<Car, bool> filter)
        {
            return _cars.Where(filter).ToList();
        }

        public List<Car> GetCarsByColorId(Func<Car, bool> filter)
        {
            return _cars.Where(filter).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Name = car.Name;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
