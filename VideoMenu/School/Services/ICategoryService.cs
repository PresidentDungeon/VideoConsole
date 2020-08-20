using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.Models;

namespace VideoMenu.Services
{
    interface ICategoryService
    {
        List<Category> GetCategories();
        void AddCategory();
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);
        Category CreateCategory();


    }
}
