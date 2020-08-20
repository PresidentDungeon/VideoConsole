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

        public Category CreateCategory()
        {
            Console.WriteLine("\nEnter category title:");
            string title = Console.ReadLine();

            while (title.Length <= 0)
            {
                Console.WriteLine("\nPlease enter a valid name");
                title = Console.ReadLine();
            }

            return new Category { title = title};
        }

        public void AddCategory()
        {
            categoryTable.AddCategory(CreateCategory());
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
