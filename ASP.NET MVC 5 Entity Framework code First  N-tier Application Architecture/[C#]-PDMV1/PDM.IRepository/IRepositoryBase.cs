using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM.IRepository
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);

        int Update(T item);

        int Delete(int id);

        int Create(T item);

        IEnumerable<T> SearchByName(string name);
    }
}
