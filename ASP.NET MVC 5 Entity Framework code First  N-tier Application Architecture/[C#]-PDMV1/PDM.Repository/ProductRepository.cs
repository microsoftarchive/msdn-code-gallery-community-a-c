using PDM.DataAccess;
using PDM.IRepository;
using PDM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM.Repository
{
    public class ProductRepository : IRepositoryBase<Product>, IProductRepository
    {
        private PDMContext context;
        public ProductRepository()
        {
            context = new PDMContext();
        }
        public IEnumerable<Product> GetAll()
        {
            return context.Product.ToList();
        }

        public Product GetByID(int id)
        {
            return context.Product.Find(id);
        }

        int IRepositoryBase<Product>.Update(Product item)
        {
            context.Entry(item).State = EntityState.Modified;
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var prodct = context.Product.Find(id);
            context.Product.Remove(prodct);
            return context.SaveChanges();
        }

        int IRepositoryBase<Product>.Create(Product item)
        {
            context.Product.Add(item);
            return context.SaveChanges();
        }

        public IEnumerable<Product> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public int Create(Product product, int productModelID, int productCategoryID, int productSubCategoryID)
        {
            product.ProductModelId = productModelID;
            product.ProductSubCategoryID = productSubCategoryID;
            product.rowguid = Guid.NewGuid();
            product.ModifiedDate = DateTime.Now;
            return (this as IRepositoryBase<Product>).Create(product);
        }


        public int Edit(Product product, int productModelID, int productSubCategoryID)
        {
            product.ProductModelId = productModelID;
            product.ProductSubCategoryID = productSubCategoryID;
            product.rowguid = Guid.NewGuid();
            product.ModifiedDate = DateTime.Now;
            return (this as IRepositoryBase<Product>).Update(product);
        }
    }
}
