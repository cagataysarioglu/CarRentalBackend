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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, DatabaseContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Func<Customer, bool> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from cu in context.Customers
                    join u in context.Users on cu.UserId equals u.Id
                    select new CustomerDetailDto{UserId = cu.UserId, Name = u.FirstName, Surname = u.LastName, CompanyName = cu.CompanyName, Email = u.Email};
                return result.ToList();
            }
        }
    }
}
