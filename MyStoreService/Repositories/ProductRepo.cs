using Microsoft.EntityFrameworkCore;
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
    public class ProductRepo : IProduct
    {
        private readonly MyStoreDbContext _dbContext;

        public ProductRepo(MyStoreDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public void DeleteProduct(ProductDM product)
        {
            _dbContext.products.Remove(product);
        }

        public List<ProductDM> GetAllProducts()
        {
            return _dbContext.products.ToList();
        }

        public ProductDM GetProductById(int id)
        {
            return _dbContext.products.Include(x => x.Categories).ThenInclude(y => y.Category).Where(v=> v.Id == id).FirstOrDefault();
            
        }

        public void InsertProduct(ProductDM product)
        {
            _dbContext.products.Add(product);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(ProductDM product)
        {
            _dbContext.products.Update(product);
        }
    }
}
