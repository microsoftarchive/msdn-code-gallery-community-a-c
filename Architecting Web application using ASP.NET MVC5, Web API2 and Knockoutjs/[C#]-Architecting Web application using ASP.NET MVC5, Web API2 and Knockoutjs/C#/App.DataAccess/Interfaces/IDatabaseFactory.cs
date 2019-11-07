namespace App.DataAccess.Interfaces
{

    /// <summary>
    /// Defines the methods that are required for a DatabaseFactory instance.
    /// </summary>
    public interface IDatabaseFactory
    {
        /// <summary>
        /// Returns a concrete instance of the CemexDb data context
        /// </summary>
        /// <returns>DbContext (CemexDb)</returns>
        CemexDb Get();
    }

}