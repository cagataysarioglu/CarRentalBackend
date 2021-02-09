using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        private List<Color> _colors;
        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Delete(Color color)
        {
            Color colorToDelete = null;
            colorToDelete = _colors.SingleOrDefault(c => c.Id == color.Id);
            _colors.Remove(colorToDelete);
        }

        public Color Get(Func<Color, bool> filter)
        {
            return _colors.SingleOrDefault(filter);
        }

        public List<Color> GetAll(Func<Color, bool> filter = null)
        {
            return filter == null ? _colors.ToList() : _colors.Where(filter).ToList();
        }

        public List<Color> GetCarsByBrandId(Func<Color, bool> filter)
        {
            return _colors.Where(filter).ToList();
        }

        public List<Color> GetCarsByColorId(Func<Color, bool> filter)
        {
            return _colors.Where(filter).ToList();
        }

        public void Update(Color color)
        {
            Color colorToUpdate = _colors.SingleOrDefault(c => c.Id == color.Id);
            colorToUpdate.Name = color.Name;
        }
    }
}
