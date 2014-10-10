using System.Collections.Generic;
using MT.ModelEntities.Entities;

namespace MT.DomainLogic
{
    /// <summary>
    /// Represents the functionality of working with technology (adds, delete and search by substring).
    /// </summary>
    public interface ITechnologyService
    {
        /// <summary>
        /// Searches a list of technology name of which contains a query substring.
        /// </summary>
        /// <param name="query">Part of a technology name</param>
        IEnumerable<Technology> Find(string query);
    }
}