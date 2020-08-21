using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.DAL;
using VideoMenu.Models;

namespace VideoMenu.Services
{
    class CategoryService : ICategoryService
    {
        private CategoryTable categoryTable;
        private VideoTable videoTable;

        public CategoryService()
        {
            this.categoryTable = CategoryTable.GetInstance();
            this.videoTable = VideoTable.GetInstance();
        }

        public Category CreateCategory(string title)
        {
            return new Category { title = title};
        }

        public void AddCategory(Category category)
        {
            categoryTable.AddCategory(category);
        }

        public List<Category> GetCategories()
        {
            return categoryTable.GetCategories();
        }

        public bool UpdateCategory(Category category)
        {
            return categoryTable.UpdateCategory(category);
        }

        public bool DeleteCategory(int id)
        {
            return categoryTable.DeleteCategory(id);
        }

    }
}
