using SportStore.Models;
using SportStore.Models.Pages;

namespace SportStore.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get;  }

        void AddCategory(Category category);

        Category GetCategory(int key);

        PageList<Category> GetCategories(QueryOptions options);

        void UpdateCategory(Category category);

        void Delete(Category category);

    }
}
