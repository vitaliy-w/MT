using System;
using System.Data.Entity;

namespace MT.DataAccess.EntityFramework
{
    /// <summary>
    /// Implements IDataAccessFactory for working with EntityFramework DbContext.
    /// </summary>
    /// <typeparam name="T">Specific DbContext used to access the DB. Must have a constructor taking a connection string as the single parameter.</typeparam>
    public class DataAccessFactory<T> : IDataAccessFactory
        where T : DbContext
    {
        private readonly string _connectionString;

        public DataAccessFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region Implementation of IDataAccessFactory

        /// <summary>
        /// Instantiates a new UnitOfWork.
        /// </summary>
        public IUnitOfWork CreateUnitOfWork()
        {
            var context = (DbContext)Activator.CreateInstance(typeof(T), _connectionString);
            return new UnitOfWork(context);
        }

        #endregion
    }
}
