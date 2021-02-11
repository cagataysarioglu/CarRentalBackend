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
            brandToDelete = _brands.SingleOrDefault(c => c.BrandId == brand.BrandId);
            _brands.Remove(brandToDelete);
        }

        public Brand Get(Func<Brand, bool> filter)
        {
            return _brands.SingleOrDefault(filter);
        }

        public List<Brand> GetAll(Func<Brand, bool> filter = null)
        {
            return filter == null ? _brands.ToList() : _brands.Where(filter).ToList();
        }

        public List<Brand> GetCarsByBrandId(Func<Brand, bool> filter)
        {
            return _brands.Where(filter).ToList();
        }

        public List<Brand> GetCarsByColorId(Func<Brand, bool> filter)
        {
            return _brands.Where(filter).ToList();
        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(c => c.BrandId == brand.BrandId);
            brandToUpdate.Name = brand.Name;
        }
    }
}
