using System.Data.Entity;
using System.Linq;

namespace MT.DataAccess.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dataContext;

        public UnitOfWork(DbContext dataContext)
        {
            _dataContext = dataContext;
            _dataContext.Configuration.LazyLoadingEnabled = true;
        }

        #region Implementation of IUnitOfWork

        /// <summary>
        /// Return a IQueryable of all data objects of the specified type.
        /// </summary>
        public IQueryable<T> Get<T>()
            where T : class
        {
            return _dataContext.Set<T>();
        }

        /// <summary>
        /// Marks object as added in the unit of work.
        /// </summary>
        public void Add<T>(T entity)
            where T : class
        {
            _dataContext.Set<T>().Add(entity);
        }
        /// <summary>
        /// Marks object as removed in the unit of work.
        /// </summary>
        public void Remove<T>(T entity)
            where T : class
        {
            _dataContext.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Commits current changes.
        /// </summary>
        public void Commit()
        {
            _dataContext.SaveChanges();
        }

        #endregion

        #region Implementation of IDisposable

        /// <summary>
        /// Cleans up external resources.
        /// </summary>
        public void Dispose()
        {
            _dataContext.Dispose();
        }

        #endregion
    }
}
