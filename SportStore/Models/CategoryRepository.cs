using SportStore.Data;
using SportStore.Interfaces;
using System.Runtime.InteropServices;

namespace SportStore.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        //private List<Category> data = new List<Category>();
        private DataContext context;

        public CategoryRepository(DataContext ctx) => context = ctx;    

        public IEnumerable<Category> Categories => context.Categories.ToArray();

        public void AddCategory(Category Category)
        {
            this.context.Categories.Add(Category);
            this.context.SaveChanges();
        }

        public Category GetCategory(int key) => context.Categories.Find(key);

        public void UpdateCategory(Category Category)
        {
            context.Categories.Update(Category);
            context.SaveChanges();
        }

        public void Delete(Category Category) 
        {
            context.Categories.Remove(Category);
            context.SaveChanges();
        }

    }
}
