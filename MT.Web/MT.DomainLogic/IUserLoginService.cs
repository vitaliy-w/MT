using System;

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
        /// <param name="userId">User's ID</param>
        /// <param name="date">Date when occur login attempt</param>
        /// <param name="result">The Success or the Failure of login attempt</param>
        void SetUserLoginHistory(int userId, DateTime date, bool result);

        /// <summary>
        /// Retrieves the user ID from given email
        /// </summary>
        /// <param name="email">User's email</param>
        /// <returns>Returns the user's ID if one exist, otherwise "-1"</returns>
        int GetUserIdFromEmail(string email);

        /// <summary>
        /// Check if user with given ID is banned
        /// </summary>
        /// <param name="userId">User's ID</param>
        /// <returns>Returns True if current user is banned, otherwise - False</returns>
        bool UserIsBan(int userId);

        /// <summary>
        /// Set the user's ban status to True or False
        /// </summary>
        /// <param name="userId">User's ID</param>
        /// <param name="ban">Sets True if need to ban current user, otherwise - False</param>
        void SetUserBan(int userId, bool ban);

        /// <summary>
        /// Retrives time when user was banned
        /// </summary>
        /// <param name="userId">User's ID</param>
        TimeSpan GetBanTime(int userId);

        /// <summary>
        /// Sets time when user was banned
        /// </summary>
        /// <param name="userId">User's ID</param>
        void SetStartBanTime(int userId);

        /// <summary>
        /// Retrieves the value user login attempt count
        /// </summary>
        /// <param name="userId">User's ID</param>
        int GetCountAttempt(int userId);

        /// <summary>
        /// Increase the attempt count value on one
        /// </summary>
        /// <param name="userId">User's ID</param>
        void SetCountAttemptToPlusOne(int userId);

        /// <summary>
        /// Set the attempt count value to zero
        /// </summary>
        /// <param name="userId">User's ID</param>
        void SetCountAttemptToZero(int userId);
    }
}
