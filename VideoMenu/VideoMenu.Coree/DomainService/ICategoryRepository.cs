
using System.Collections.Generic;
using VideoMenu.Core.Entity;

namespace VideoMenu.Core.DomainService
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        IEnumerable<Category> GetCategories();
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);
    }
}
