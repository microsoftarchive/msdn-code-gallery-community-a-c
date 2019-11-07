using PDM.DataAccess;
using PDM.IRepository;
using PDM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PDM.Repository
{
    public class ProductModelRepository : IRepositoryBase<ProductModel>
    {
        private PDMContext context;

        public ProductModelRepository()
        {
            context = new PDMContext();
        }
        public IEnumerable<ProductModel> GetAll()
        {
            return context.ProductModel.OrderByDescending(x => x.ModifiedDate).ToList();
        }

        public ProductModel GetByID(int id)
        {
            return context.ProductModel.Find(id);
        }

        public int Update(ProductModel item)
        {
            item.ModifiedDate = DateTime.Now;
            context.Entry(item).State = EntityState.Modified;
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var model = context.ProductModel.Find(id);
            context.ProductModel.Remove(model);
            return context.SaveChanges();
        }

        public int Create(ProductModel item)
        {
            item.rowguid = Guid.NewGuid();
            item.ModifiedDate = DateTime.Now;
            context.ProductModel.Add(item);
            return context.SaveChanges();
        }

        public IEnumerable<ProductModel> SearchByName(string name)
        {
            return context.ProductModel.Where(x => x.Name == name).ToList();
        }
    }
}
