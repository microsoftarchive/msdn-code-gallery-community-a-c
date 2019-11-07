#region

using System.Data.Entity;

#endregion

namespace BTL.DataAccess
{
    public class NullDatabaseInitializer<TContext> :
        IDatabaseInitializer<TContext> where TContext : DbContext
    {
        #region IDatabaseInitializer<TContext> Members

        public void InitializeDatabase(TContext context)
        {
        }

        #endregion
    }
}