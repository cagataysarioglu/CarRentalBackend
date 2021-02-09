using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        private List<Brand> _brands;
        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = null;
            brandToDelete = _brands.SingleOrDefault(c => c.Id == brand.Id);
            _brands.Remove(brandToDelete);
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            return _brands.SingleOrDefault(filter.Compile());
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return filter == null ? _brands.ToList() : _brands.Where(filter.Compile()).ToList();
        }

        public List<Brand> GetCarsByBrandId(Expression<Func<Brand, bool>> filter)
        {
            return _brands.Where(filter.Compile()).ToList();
        }

        public List<Brand> GetCarsByColorId(Expression<Func<Brand, bool>> filter)
        {
            return _brands.Where(filter.Compile()).ToList();
        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(c => c.Id == brand.Id);
            brandToUpdate.Name = brand.Name;
        }
    }
}
