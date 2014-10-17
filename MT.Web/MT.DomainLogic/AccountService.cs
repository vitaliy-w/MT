using System;
using System.Linq;
using MT.DataAccess.EntityFramework;
using MT.ModelEntities.Entities;

namespace MT.DomainLogic
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// add a new user
        /// </summary>
        /// <param name="user">new user</param>
        public void RegisterUser(User user)
        {
            user.Created = DateTime.Now;
            _unitOfWork.Add(user);
        }


        /// <summary>
        /// verifies the existence of such E-mail in the database 
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true - if this Email is already in the database</returns>
        public bool CheckEmail(string email)
        {
            var result = _unitOfWork.Get<User>().Any(u => u.Email == email);
            return result;

        }

    }
}
