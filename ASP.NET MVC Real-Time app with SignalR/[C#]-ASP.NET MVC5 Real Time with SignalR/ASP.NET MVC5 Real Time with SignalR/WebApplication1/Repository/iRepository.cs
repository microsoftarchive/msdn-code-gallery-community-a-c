using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> ExecuteQuery(string spQuery, object[] parameters);
        T ExecuteQuerySingle(string spQuery, object[] parameters);
        int ExecuteCommand(string spQuery, object[] parameters);
    }
}
