using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.Models;

namespace VideoMenu.Services
{
    interface ICategoryService
    {
        List<Category> GetCategories();
        void AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);
        Category CreateCategory(string title);


    }
}
