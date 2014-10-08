﻿using System;
using System.Linq;
using MT.DataAccess.EntityFramework;
using MT.ModelEntities.Entities;

namespace MT.DomainLogic.AccountService
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
        /// метод вызывается при регистрации пользователя через сервисы
        /// </summary>
        /// <param name="id">параметр получаем с сервисов</param>
        /// <param name="userName">параметр получаем с сервисов</param>
        /// <param name="provider">параметр получаем с сервисов</param>
        public void RegisterExternalUser(string id, string userName, string provider)
        {
            var user = new ExternalUser();
            user.ProviderUserId = id;
            user.UserName = userName;
            user.Provider = provider;
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
