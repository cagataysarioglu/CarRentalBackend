using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<Rental> GetById(int id);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetRentalsByCustomerId(int userId);
        IDataResult<List<RentalDetailDto>> GetRentalDetails(int id);
        IResult Update(Rental car);
        IResult Delete(Rental car);
        IResult Add(Rental car);
    }
}
