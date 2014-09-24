namespace MT.DataAccess.EntityFramework
{
    /// <summary>
    /// Provides object for data access.
    /// </summary>
    public interface IDataAccessFactory
    {
        /// <summary>
        /// Instantiates a new UnitOfWork.
        /// </summary>
        IUnitOfWork CreateUnitOfWork();
    }
}
