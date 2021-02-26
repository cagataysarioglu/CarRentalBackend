using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetCarImagesByCarId(int id);
        IDataResult<CarImage> Get(int id);
        IResult Add(CarImage carImage, string path);
        IResult Update(CarImage carImage);
        IResult Delete(CarImage carImage);
    }
}
