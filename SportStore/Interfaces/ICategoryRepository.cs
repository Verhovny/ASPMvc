using SportStore.Models;

namespace SportStore.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get;  }

        void AddCategory(Category category);

        Category GetCategory(int key);

        void UpdateCategory(Category category);

        void Delete(Category category);

    }
}
