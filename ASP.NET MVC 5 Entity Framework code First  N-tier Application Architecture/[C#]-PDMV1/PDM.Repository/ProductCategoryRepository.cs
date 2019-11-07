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
    public class ProductCategoryRepository : IRepositoryBase<ProductCategory>
    {
        private PDMContext context;
        public ProductCategoryRepository()
        {
            context = new PDMContext();
        }
        public IEnumerable<ProductCategory> GetAll()
        {
            return context.ProductCategory.OrderByDescending(x => x.ModifiedDate).ToList();
        }

        public ProductCategory GetByID(int id)
        {
            return context.ProductCategory.Find(id);
        }

        public int Update(ProductCategory item)
        {
            item.ModifiedDate = DateTime.Now;
            context.Entry(item).State = EntityState.Modified;
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var catgory = context.ProductCategory.Find(id);
            context.ProductCategory.Remove(catgory);
            return context.SaveChanges();
        }

        public int Create(ProductCategory item)
        {
            item.rowguid = Guid.NewGuid();
            item.ModifiedDate = DateTime.Now;
            context.ProductCategory.Add(item);
            return context.SaveChanges();
        }

        public IEnumerable<ProductCategory> SearchByName(string name)
        {
            return context.ProductCategory.Where(x => x.Name == name).ToList();
        }
    }
}
