using MyStore.Areas.Identity.Data;
using MyStore.Models;
using MyStoreService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStoreService.Repositories
{
    public class CategoryRepo : ICategory
    {
        private readonly MyStoreDbContext  _dbContext;  
        public CategoryRepo(MyStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteCategory(CategoryDM category)
        {
            _dbContext.categories.Remove(category);  
        }

        public List<CategoryDM> GetAllCategories()
        {
            return _dbContext.categories.ToList();
        }

        public CategoryDM GetCategoryById(int id)
        {
            return _dbContext.categories.Where(e=>e.Id == id).FirstOrDefault();
        }

        public void InsertCategory(CategoryDM category)
        {
            _dbContext.categories.Add(category);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateCategory(CategoryDM category)
        {
            _dbContext.categories.Update(category);
        }
    }
}
