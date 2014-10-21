using System;
using System.Linq;
using MT.DataAccess.EntityFramework;
using MT.ModelEntities.Entities;

namespace MT.DomainLogic
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserLoginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool ValidateUser(string email, string password)
        {
            return _unitOfWork.Get<User>().Any(u => u.Email == email.ToLower() && u.Password == password);
        }

        public void UserLoginHistory(UserLoginHistory userLoginHistory)
        {
            _unitOfWork.Add(userLoginHistory);
        }

        public User GetUserFromEmail(string email)
        {
            return _unitOfWork.Get<User>().FirstOrDefault(u => u.Email == email.ToLower());
        }

        public UserBan GetUserBan(int userId)
        {
            return _unitOfWork.Get<UserBan>().First(u => u.UserId == userId);
        }

        public int GetBanTime(UserBan userBan)
        {
            var startBanTime = userBan.StartBanTime;
            var timeNow = DateTime.Now;
            var banTime = timeNow - startBanTime;
            return (int)banTime.TotalMinutes;
        }
    }
}
