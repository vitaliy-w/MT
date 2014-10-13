using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MT.DataAccess.EntityFramework;
using MT.DomainLogic.Localization;
using MT.ModelEntities.Entities;
using MT.ModelEntities.Enums;
using MT.Utility.Json;
using MT.Utility.OtherTools;
using MT.Web.Infrastructure.Extensions;
using MT.Web.Models;
using MT.Utility.OtherTools;

namespace MT.Web.Areas.Management.Controllers
{
    public class LocalizationController : Controller
    {
        private IUnitOfWork db;
        private ILocalizationResourceService _localizationResourceService;

        /// <summary>
        /// Метод для заполнения пустой базы данных тестовыми значениями. Убрать перед релизом. 
        /// </summary>

        [Obsolete("Delete it before release")]
        private void InitEmptyDb()
        {
            db.Add(new LocalizationResource() { ResourceKey = "Password", ResourceCultureCode = "ru-RU", LocalizedResource = "Пароль" });
            db.Add(new LocalizationResource() { ResourceKey = "Sign", ResourceCultureCode = "ru-RU", LocalizedResource = "Войти" });
            db.Add(new LocalizationResource() { ResourceKey = "Registration", ResourceCultureCode = "ru-RU", LocalizedResource = "Регистрация" });
            db.Add(new LocalizationResource() { ResourceKey = "About us", ResourceCultureCode = "ru-RU", LocalizedResource = "Про нас" });
            db.Add(new LocalizationResource() { ResourceKey = "Help", ResourceCultureCode = "ru-RU", LocalizedResource = "Помощь" });
            db.Commit();
        }

        public LocalizationController(IUnitOfWork unitOfWork, ILocalizationResourceService localizationService)
        {
            this.db = unitOfWork;
           _localizationResourceService = localizationService;
            // InitEmptyDb();

        }
        /// <summary>
        /// Основная страница которая выводит в таблице все ресурсы локализации из базы данных. 
        /// </summary>
        public ActionResult Index()
        {
            var model = db.Get<LocalizationResource>();
            return View(model);

        }


        /// <summary>
        /// Page for adding new resources/
        /// </summary>
        public ActionResult AddLocalizationResource()
        {
            return View();
        }


        /// <summary>
        /// Checks new resource from client and add it to data base if correct.
        /// </summary>

        [HttpPost]
        public string Create(LocalizationResourceViewModel result)
        {

            if (!ModelState.IsValid)
            {
                return new ErrorModel("Error", 0).ToJson();
            }


            int addedEntryies = _localizationResourceService.SafeAddUniqueEntry(result.GetLocalizationResources());
            if (addedEntryies<1)  return new ErrorModel("Error", 0).ToJson();


            db.Commit();
            return null;


        }












    }
}
