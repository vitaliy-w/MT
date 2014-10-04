using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MT.DataAccess.EntityFramework;
using MT.ModelEntities.Entities;

namespace MT.Web.Areas.Management.Controllers
{
    public class LocalizationController : Controller
    {
        private IUnitOfWork db;

        public LocalizationController(IUnitOfWork unitOfWork)
        {
            this.db = unitOfWork;
            // db.Add(new LocalizationResource() { ResourceKey = "Login", ResourceCultureCode = "ru-RU", LocalizedResource = "Логин" });
            //db.Commit();             System.Data.Entity.Infrastructure.DbUpdateException //An exception of type 'System.Data.Entity.Core.EntityCommandExecutionException' occurred in mscorlib.dll but was not handled in user code

            //db.Add(new LocalizationResource() { ResourceKey = "Password", ResourceCultureCode = "ru-RU", LocalizedResource = "Пароль" });
            //db.Add(new LocalizationResource() { ResourceKey = "Sign", ResourceCultureCode = "ru-RU", LocalizedResource = "Войти" });
            //db.Add(new LocalizationResource() { ResourceKey = "Registration", ResourceCultureCode = "ru-RU", LocalizedResource = "Регистрация" });
            //db.Add(new LocalizationResource() { ResourceKey = "About us", ResourceCultureCode = "ru-RU", LocalizedResource = "Про нас" });
            //db.Add(new LocalizationResource() { ResourceKey = "Help", ResourceCultureCode = "ru-RU", LocalizedResource = "Помощь" });

        }
        /// <summary>
        /// Основная страница которая выводит в таблице все ресурсы локализации из базы данных. 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {


            var model = db.Get<LocalizationResource>();

            return View(model);

        }

        /// <summary>
        /// Страница для добавления нового ресурса
        /// </summary>
        /// <returns></returns>

        public ActionResult Create()
        {
            return View();
        }


    }
}
