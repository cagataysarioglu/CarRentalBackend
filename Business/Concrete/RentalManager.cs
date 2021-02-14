using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental car)
        {
            if (car.RentDate.DayOfYear > 0)
            {
                _rentalDal.Add(car);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.NotAdded);
            }
        }

        public IResult Delete(Rental car)
        {
            if (car.RentalId != 0)
            {
                _rentalDal.Delete(car);
                return new SuccessResult(Messages.Deleted);
            }
            else
            {
                return new ErrorResult(Messages.NotDeleted);
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 23)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new DataResult<List<Rental>>(_rentalDal.GetAll(), true, Messages.Listed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 23)
            {
                return new ErrorDataResult<Rental>(Messages.MaintenanceTime);
            }
            return new DataResult<Rental>(_rentalDal.Get(c => c.CarId == id), true, Messages.Listed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails(int id)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 23)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.MaintenanceTime);
            }
            return new DataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(c => c.CarId == id), true, Messages.Listed);
        }

        public IDataResult<List<Rental>> GetRentalsByCustomerId(int userId)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 23)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new DataResult<List<Rental>>(_rentalDal.GetRentalsByCustomerId(c => c.CustomerId == userId), true, Messages.Listed);
        }

        public IResult Update(Rental car)
        {
            _rentalDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
    }
}
