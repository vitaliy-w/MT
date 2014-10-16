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
            return _unitOfWork.Get<User>().Any(u => u.Email == email && u.Password == password);
        }

        public void SetUserLoginHistory(int userId, DateTime date, bool result)
        {
            _unitOfWork.Add(new UserLoginHistory { UserId = userId, LoginDate = date, LoginResult = result });
        }

        public int GetUserIdFromEmail(string email)
        {
            try
            {
                return _unitOfWork.Get<User>().Where(u => u.Email == email).Select(u => u.Id).First();
            }
            catch (Exception)
            {

                return -1;
            }
        }

        public bool UserIsBan(int userId)
        {
            return _unitOfWork.Get<UserBan>().Where(u => u.UserId == userId).Select(u => u.UserIsBan).First();
        }

        public void SetUserBan(int userId, bool ban)
        {
            var userBan = _unitOfWork.Get<UserBan>().First(u => u.UserId == userId);
            userBan.UserIsBan = ban;
        }

        public TimeSpan GetBanTime(int userId)
        {
            var startBanTime = _unitOfWork.Get<UserBan>().Where(u => u.UserId == userId).Select(u => u.StartBanTime).First();
            var timeNow = DateTime.Now;
            var banTime = timeNow - startBanTime;
            return banTime;
        }

        public void SetStartBanTime(int userId)
        {
            var userBan = _unitOfWork.Get<UserBan>().First(u => u.UserId == userId);
            userBan.StartBanTime = DateTime.Now;
        }

        public int GetCountAttempt(int userId)
        {
            return _unitOfWork.Get<UserBan>().Where(u => u.UserId == userId).Select(u => u.AttemptCount).First();
        }

        public void SetCountAttemptToPlusOne(int userId)
        {
            var userBan = _unitOfWork.Get<UserBan>().First(u => u.UserId == userId);
            userBan.AttemptCount++;
        }

        public void SetCountAttemptToZero(int userId)
        {
            var userBan = _unitOfWork.Get<UserBan>().First(u => u.UserId == userId);
            userBan.AttemptCount = 0;
        }
    }
}
