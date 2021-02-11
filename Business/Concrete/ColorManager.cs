using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        IDataResult<List<Color>> IColorService.GetAll()
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 23)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }
            return new DataResult<List<Color>>(_colorDal.GetAll(), true, Messages.Listed);_colorDal.GetAll();
        }

        IDataResult<List<Color>> IColorService.GetById(int colorId)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 23)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }
            return new DataResult<List<Color>>(_colorDal.GetAll(c => c.Id == colorId), true, Messages.Listed);_colorDal.GetAll(c => c.Id == colorId);
        }
    }
}
