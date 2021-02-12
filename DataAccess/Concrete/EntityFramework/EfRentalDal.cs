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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, DatabaseContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Func<Rental, bool> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from r in context.Rentals
                    join ca in context.Cars on r.CarId equals ca.CarId
                    join cu in context.Customers on r.CustomerId equals cu.UserId
                    select new RentalDetailDto{RentalId = r.RentalId, CarId = ca.CarId, CustomerId = cu.UserId, RentDate = r.RentDate, ReturnDate = r.ReturnDate};
                return result.ToList();
            }
        }

        public List<Rental> GetRentalsByCustomerId(Func<Rental, bool> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return filter == null ? context.Set<Rental>().ToList() : context.Set<Rental>().Where(filter).ToList();
            }
        }
    }
}
