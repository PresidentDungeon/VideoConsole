using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.Core.Entity;

namespace VideoMenu.Core.ApplicationService
{
   public interface ICategoryService
    {
        Category CreateCategory(string title);
        void AddCategory(Category category);
        List<Category> GetCategories();
        bool UpdateCategory(Category category, int id);
        bool DeleteCategory(int id);

    }
}
