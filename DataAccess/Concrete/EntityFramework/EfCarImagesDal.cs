using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImagesDal : EfEntityRepositoryBase<CarImage, DatabaseContext>, ICarImageDal
    {
        public List<CarImage> GetCarImagesByCarId(Func<CarImage, bool> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return filter == null ? context.Set<CarImage>().ToList() : context.Set<CarImage>().Where(filter).ToList();
            }
        }
    }
}
