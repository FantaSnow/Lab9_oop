using System.Collections.Generic;
using System.Linq;
using Lab9.Domain;
using Lab9.Service.Interfaces;

namespace Lab9.Service.Servises
{
    public class CategoryService : ICategoryService
    {
        private readonly List<Category> _categorys = new List<Category>();
        private int _nextId = 1;

        public bool AddCategory(Category category)
        {
            if (category == null)
                return false;
            category.Id = _nextId++;
            _categorys.Add(category);
            return true;
        }

        public bool EditCategory(Category category)
        {
            var existingBook = _categorys.FirstOrDefault(c => c.Id == category.Id);
            if (category == null || existingBook == null)
                return false;

            existingBook.Name = category.Name;
            return true;
        }

        public bool DeleteCategory(string name)
        {
            var category = _categorys.FirstOrDefault(c => c.Name == name);
            if (category == null)
                return false;
            _categorys.Remove(category);
            return true;
        }

        public List<Category> GetAllCategory()
        {
            return _categorys;
        }
    }
}