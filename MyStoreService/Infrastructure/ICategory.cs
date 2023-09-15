using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStoreService.Infrastructure
{
    public interface ICategory
    {
        List<CategoryDM> GetAllCategories();  
        CategoryDM GetCategoryById(int id);
        void InsertCategory(CategoryDM category);
        void UpdateCategory(CategoryDM category);
        void DeleteCategory(CategoryDM category);
        void Save();
    }
}
