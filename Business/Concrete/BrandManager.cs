using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        IDataResult<List<Brand>> IBrandService.GetAll()
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 23)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }
            return new DataResult<List<Brand>>(_brandDal.GetAll(), true, Messages.Listed);_brandDal.GetAll();
        }

        IDataResult<List<Brand>> IBrandService.GetById(int brandId)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 23)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }
            return new DataResult<List<Brand>>(_brandDal.GetAll(c => c.Id == brandId), true, Messages.Listed);_brandDal.GetAll(c => c.Id == brandId);
        }
    }
}
