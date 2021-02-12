using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Func<Car, bool> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from ca in context.Cars
                    join b in context.Brands on ca.BrandId equals b.BrandId
                    join co in context.Colors on ca.ColorId equals co.ColorId 
                    select new CarDetailDto{CarId = ca.CarId, Name = ca.Name, BrandName = b.Name, ColorName = co.Name, ModelYear = ca.ModelYear, DailyPrice = ca.DailyPrice};
                return result.ToList();
            }
        }

        public List<Car> GetCarsByBrandId(Func<Car, bool> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public List<Car> GetCarsByColorId(Func<Car, bool> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }
    }
}
