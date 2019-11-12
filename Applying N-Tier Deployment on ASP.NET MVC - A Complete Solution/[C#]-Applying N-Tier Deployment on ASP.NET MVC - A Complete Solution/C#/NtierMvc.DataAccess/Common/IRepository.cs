using System;
using System.Collections.Generic;
using System.Linq;

namespace NtierMvc.DataAccess.Common
{
    /// <summary>
    /// Purpose: Interface contains common methods implemented by all repository classes.
    /// </summary>
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Methods
        bool Insert(TEntity entity);
        bool Update(TEntity entity);
        bool DeleteById(int id);
        TEntity SelectById(int id);
        List<TEntity> SelectAll();
        #endregion
    }
}
