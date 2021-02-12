using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetRentalDetails(Func<Rental,bool> filter = null);
        List<Rental> GetRentalsByCustomerId(Func<Rental,bool> filter = null);

    }
}
