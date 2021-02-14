using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int customerId);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails(int id);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
        IResult Add(Customer customer);
    }
}
