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
    public class ProductSubCategoryRepository : IRepositoryBase<ProductSubCategory>, IProductSubCategoryRepository
    {
        private PDMContext context;
        public ProductSubCategoryRepository()
        {
            context = new PDMContext();
        }
        public IEnumerable<ProductSubCategory> GetAll()
        {
            return context.ProductSubCategory.OrderByDescending(x => x.ModifiedDate).ToList();
        }

        public ProductSubCategory GetByID(int id)
        {
            return context.ProductSubCategory.Find(id);
        }

        public int Update(ProductSubCategory item)
        {
            item.CategoryName = context.ProductCategory.Where(x => x.ProductCategoryID == item.ProductCategoryID).Select(y => y.Name).FirstOrDefault();
            item.ModifiedDate = DateTime.Now;
            context.Entry(item).State = EntityState.Modified;
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var catgory = context.ProductSubCategory.Find(id);
            context.ProductSubCategory.Remove(catgory);
            return context.SaveChanges();
        }

        int IRepositoryBase<ProductSubCategory>.Create(ProductSubCategory item)
        {
            context.ProductSubCategory.Add(item);
            return context.SaveChanges();
        }

        public IEnumerable<ProductSubCategory> SearchByName(string name)
        {
            return context.ProductSubCategory.Where(x => x.Name == name).ToList();
        }

        public int CreateProductSubCategory(ProductSubCategory item, int ProductCategoryID)
        {
            var category = context.ProductCategory.Find(ProductCategoryID);
            item.CategoryName = category.Name;
            item.ProductCategoryID = ProductCategoryID;
            item.rowguid = Guid.NewGuid();
            item.ModifiedDate = DateTime.Now;
            return (this as IRepositoryBase<ProductSubCategory>).Create(item);
        }
    }
}
