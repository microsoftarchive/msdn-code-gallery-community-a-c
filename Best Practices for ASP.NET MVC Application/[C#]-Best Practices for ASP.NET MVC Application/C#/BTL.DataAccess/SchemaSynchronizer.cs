#region

using System;
using System.Data.Entity;
using System.Diagnostics.Contracts;

#endregion

namespace BTL.DataAccess
{
    public class SchemaSynchronizer
    {
        private readonly Func<bool> debugMode;

        public SchemaSynchronizer(Func<bool> debugMode)
        {
            //Contract.Requires<ArgumentNullException>(debugMode != null);

            this.debugMode = debugMode;
        }

        public void Execute()
        {
            var initializer = debugMode()
                                  ? new DropCreateDatabaseAlways<DataContext>()
                                  : new NullDatabaseInitializer<DataContext>()
                                    as IDatabaseInitializer<DataContext>;

            Database.SetInitializer(initializer);
        }
    }
}