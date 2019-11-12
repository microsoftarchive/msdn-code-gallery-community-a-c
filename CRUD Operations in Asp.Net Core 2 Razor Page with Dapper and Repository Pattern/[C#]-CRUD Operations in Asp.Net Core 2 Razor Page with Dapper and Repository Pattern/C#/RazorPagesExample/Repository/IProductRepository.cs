using RazorPagesExample.Entity;
using System.Collections.Generic;

namespace RazorPagesExample.Repository
{
    public interface IProductRepository
    {
        int Add(Product product);

        List<Product> GetList();

        Product GetProduct(int id);

        int EditProduct(Product product);

        int DeleteProdcut(int id);
    }
}
