using System.Collections.Generic;

namespace App.DataAccess.Interfaces
{

    public interface IRepository<T> where T : class
    {
        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
        T GetById(int Id);
        IEnumerable<T> All();
    }

}