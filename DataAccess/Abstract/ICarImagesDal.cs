using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarImagesDal : IEntityRepository<CarImage>
    {
        List<CarImage> GetCarImagesByCarId(Func<CarImage,bool> filter = null);
    }
}
