using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MT.DataAccess.EntityFramework
{
    /// <summary>
    /// Contains extension mwthods for the IUnitOfWork interface.
    /// </summary>
    public static class UnitOfWorkExtensions
    {
        /// <summary>
        /// Gets a single instance of the specified entity type that satisfies the predicate.
        /// </summary>
        public static T FirstOrDefault<T>(this IUnitOfWork unitOfWork, Expression<Func<T, bool>> predicate)
            where T : class
        {
            return unitOfWork.Get<T>().FirstOrDefault(predicate);
        }

        /// <summary>
        /// Removes the items by the specified predicate
        /// </summary>
        public static void RemoveItems<T>(this IUnitOfWork unitOfWork, Expression<Func<T, bool>> predicate)
            where T : class
        {
            var deleteItems = unitOfWork.Get<T>().Where(predicate);
            foreach (var deleteItem in deleteItems)
            {
                unitOfWork.Remove(deleteItem);
            }
        }

        /// <summary>
        /// Removes items
        /// </summary>
        public static void RemoveItems<T>(this IUnitOfWork unitOfWork, IEnumerable<T> items)
            where T : class
        {
            foreach (var item in items)
            {
                unitOfWork.Remove(item);
            }
        }

        /// <summary>
        /// Adds items
        /// </summary>
        public static void AddItems<T>(this IUnitOfWork unitOfWork, IEnumerable<T> items)
               where T : class
        {
            foreach (var item in items)
            {
                unitOfWork.Add(item);
            }
        }
    }
}
