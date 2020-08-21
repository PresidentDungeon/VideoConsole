
namespace VideoMenu.Core.DomainService
{
    interface ICategoryRepository
    {
        Category CreateCategory(string title);
        void Create(Category category);
        List<Category> ReadAll();
        bool Update(Category category);
        bool Delete(int id);

    }
}
