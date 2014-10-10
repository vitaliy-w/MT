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
        /// метод который вызывается при регистрации пользователя через форму
        /// </summary>
        /// <param name="user">новый пользователь с формы регистрации</param>
        public void RegisterUser(User user)
        {
            user.Created = DateTime.Now;
            _unitOfWork.Add(user);
        }


        /// <summary>
        /// проверяет есть ли такая почта в базе
        /// </summary>
        /// <param name="email">значение с текстбокса формы</param>
        /// <returns>true - если такая почта уже есть в базе</returns>
        public bool CheckEmail(string email)
        {
            var result = _unitOfWork.Get<User>().Any(u => u.Email == email);
            return result;

        }

    }
}
