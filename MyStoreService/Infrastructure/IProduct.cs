using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStoreService.Infrastructure
{
    public interface IProduct
    {
        List<ProductDM> GetAllProducts();
        ProductDM GetProductById(int id);
        void InsertProduct(ProductDM product);
        void UpdateProduct(ProductDM product);
        void DeleteProduct(ProductDM product);
        void Save();

    }
}
