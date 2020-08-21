using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenu.Core.DomainService;
using VideoMenu.Core.Entity;

namespace VideoMenu.Core.ApplicationService.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public Category CreateCategory(string title)
        {
            return new Category { title = title };
        }

        public void AddCategory(Category category)
        {
            categoryRepository.AddCategory(category);
        }

        public List<Category> GetCategories()
        {
            return categoryRepository.GetCategories().ToList();
        }

        public bool UpdateCategory(Category category, int id)
        {
            category.id = id;
            return categoryRepository.UpdateCategory(category);
        }

        public bool DeleteCategory(int id)
        {
            return categoryRepository.DeleteCategory(id);
        }

    }
}
