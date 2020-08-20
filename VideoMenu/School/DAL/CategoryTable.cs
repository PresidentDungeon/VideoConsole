using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenu.Models;

namespace VideoMenu.DAL
{
    class CategoryTable
    {
        private int id;
        private List<Category> categories;
        private static CategoryTable categoryTable;

        private CategoryTable()
        {
            id = 0;
            categories = new List<Category>();
            CreateInitialCategories();
        }

        public static CategoryTable GetInstance()
        {
            return categoryTable ??= new CategoryTable();
        }

        private void CreateInitialCategories()
        {
            AddCategory(new Category { title = "Action"});
            AddCategory(new Category { title = "Comdey"});
            AddCategory(new Category { title = "Drama"});
            AddCategory(new Category { title = "Fantasy"});
            AddCategory(new Category { title = "Horror"});
            AddCategory(new Category { title = "Mystery"});
            AddCategory(new Category { title = "Thriller"});
        }

        public List<Category> GetCategories()
        {
            return this.categories;
        }

        public void AddCategory(Category category)
        {
            id++;
            category.id = id;
            categories.Add(category);
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                categories.FirstOrDefault((x) => { return x.id == category.id; }).title = category.title;
                return true;
            }
            catch(ArgumentException ex)
            {
                return false;
            }
        }

        public bool DeleteCategory(int id)
        {
            Category category = categories.Where((x) => { return x.id == id; }).FirstOrDefault();
            if (category != null)
            {
                categories.Remove(category);
                return true;
            }
            return false;
        }
    }


}
