using System.Collections.Generic;
using MT.ModelEntities.Entities;

namespace MT.DomainLogic.PersonalCabinet
{
    public interface IUserEducationService
    {
        /// <summary>
        /// Adds new UserEducation or Edit UserEducation if it is already exists in DB.
        /// </summary>
        void Add(UserEducation userEducationFromClient);
        /// <summary>
        /// Gets list of UserEducation's using userEmail key.
        /// </summary>
        List<UserEducation> GetList(string userEmail);


    }
}
