using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenu.Core.DomainService;
using VideoMenu.Core.Entity;

namespace VideoMenu.Infrastructure.Static.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private int id;
        private List<Category> categories;
        private static CategoryRepository categoryRepository;

        private CategoryRepository()
        {
            id = 0;
            categories = new List<Category>();
            CreateInitialData();
        }

        public static CategoryRepository GetInstance()
        {
            return categoryRepository ??= new CategoryRepository();
        }

        public void AddCategory(Category category)
        {
            id++;
            category.id = id;
            categories.Add(category);
        }

        public List<Category> GetCategories()
        {
            return this.categories;
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                categories.FirstOrDefault((x) => { return x.id == category.id; }).title = category.title;
                return true;
            }
            catch (ArgumentException ex)
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
                category.title = null;
                return true;
            }
            return false;
        }

        private void CreateInitialData()
        {
            AddCategory(new Category { title = "Action" });
            AddCategory(new Category { title = "Comdey" });
            AddCategory(new Category { title = "Drama" });
            AddCategory(new Category { title = "Fantasy" });
            AddCategory(new Category { title = "Horror" });
            AddCategory(new Category { title = "Mystery" });
            AddCategory(new Category { title = "Thriller" });
        }
    }
}
