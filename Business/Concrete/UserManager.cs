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
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            if (user.Name.Length > 2 && user.Surname.Length > 2 && user.Password.Length > 3)
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.NotAdded);
            }
        }

        public IResult Delete(User user)
        {
            if (user.UserId != 0)
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.Deleted);
            }
            else
            {
                return new ErrorResult(Messages.NotDeleted);
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 23)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }
            return new DataResult<List<User>>(_userDal.GetAll(), true, Messages.Listed);
        }

        public IDataResult<User> GetById(int userId)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 23)
            {
                return new ErrorDataResult<User>(Messages.MaintenanceTime);
            }
            return new DataResult<User>(_userDal.Get(c => c.UserId == userId), true, Messages.Listed);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }
    }
}
