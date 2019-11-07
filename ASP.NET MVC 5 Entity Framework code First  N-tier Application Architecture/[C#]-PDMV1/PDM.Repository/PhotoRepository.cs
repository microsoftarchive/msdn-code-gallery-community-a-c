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
    public class PhotoRepository : IRepositoryBase<Photo>
    {
        private PDMContext context;
        public PhotoRepository()
        {
            context = new PDMContext();
        }
        public IEnumerable<Photo> GetAll()
        {
            return context.Photo.ToList();
        }

        public Photo GetByID(int id)
        {
            return context.Photo.Find(id);
        }

        public int Update(Photo item)
        {
            item.ModifiedDate = DateTime.Now;
            context.Entry(item).State = EntityState.Modified;
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var model = context.Photo.Find(id);
            context.Photo.Remove(model);
            return context.SaveChanges();
        }

        public int Create(Photo item)
        {
            item.rowguid = Guid.NewGuid();
            item.ModifiedDate = DateTime.Now;
            context.Photo.Add(item);
            context.SaveChanges();
            return item.PhotoID;
        }

        public IEnumerable<Photo> SearchByName(string name)
        {
            return context.Photo.Where(x => x.Name == name).ToList();
        }
    }
}
