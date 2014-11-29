using MT.ModelEntities.Entities;

namespace MT.DomainLogic.PersonalCabinet
{
    public interface IUserService
    {

        
        /// <summary>
        /// Adds new UserInfo or Edit UserInfo if it is already exists in DB.
        /// </summary>
        void Add(UserInfo userInfo);

        /// <summary>
        /// Checks if current user's id already exists in the DB.
        /// </summary>
        bool IsPresent(string userEmail);

        
        /// <summary>
        /// Gets UserInfo via userEmail
        /// </summary>
        UserInfo Get(string userEmail);

    }
}
