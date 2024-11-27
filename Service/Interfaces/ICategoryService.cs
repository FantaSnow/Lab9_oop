using System.Collections.Generic;
using Lab9.Domain;

namespace Lab9.Service.Interfaces
{
    public interface ICategoryService
    {
        bool AddCategory(Category category);
        bool EditCategory(Category category);
        bool DeleteCategory(string name);
        List<Category> GetAllCategory();
    }
}