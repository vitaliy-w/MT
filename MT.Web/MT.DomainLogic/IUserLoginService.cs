using System;
using MT.ModelEntities.Entities;

namespace MT.DomainLogic
{
    /// <summary>
    /// Represents the functionality for work with user authorization
    /// </summary>
    public interface IUserLoginService
    {
        /// <summary>
        /// Check if is registered user with set email and password
        /// </summary>
        /// <returns>Returns True if user with set parameters exists, otherwise returns False</returns>
        bool ValidateUser(string email, string password);

        /// <summary>
        /// Records user's login attempt
        /// </summary>
        /// <param name="userLoginHistory">User's ID</param>
        void UserLoginHistory(UserLoginHistory userLoginHistory);

        /// <summary>
        /// Retrieves the instance of User from given email
        /// </summary>
        /// <param name="email">User's email</param>
        User GetUserFromEmail(string email);
        
        /// <summary>
        /// Retrieves the instance of UserBan from given user ID
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>Instance of UserBan</returns>
        UserBan GetUserBan(int userId);
        
        /// <summary>
        /// Retrives time when user was banned
        /// </summary>
        /// <param name="userBan">Instance of UserBan</param>
        int GetBanTime(UserBan userBan);
}
}
