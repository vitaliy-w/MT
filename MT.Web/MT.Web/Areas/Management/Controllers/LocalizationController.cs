using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MT.DataAccess.EntityFramework;
using MT.ModelEntities.Entities;
using MT.ModelEntities.Enums;
using MT.Utility.OtherTools;
using MT.Web.Infrastructure.Extensions;
using MT.Web.Models;

namespace MT.Web.Areas.Management.Controllers
{
    public class LocalizationController : Controller
    {
        private IUnitOfWork db;

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

        public LocalizationController(IUnitOfWork unitOfWork)
        {
            this.db = unitOfWork;
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
        public HtmlString Create(LocalizationResourceViewModel result)
        {

            if (!ModelState.IsValid)
            {
                return AngularHtmlHelperExtensions.AlertDirective(null, "Model is invalid", null, AlertTypesEnum.Danger);
            }

            int itemsAddedToDB = 0;
            for (int i = 0; i < result.LocalizedResources.Length; i++)
            {
                var localizationResource = new LocalizationResource
                {
                    ResourceKey = result.ResourceKey,
                    ResourceCultureCode = result.ResourceCultureCodes[i].GetEnumStringValue(),
                    LocalizedResource = result.LocalizedResources[i]
                };

                var isPresent = db.Get<LocalizationResource>().Any(resource => ((resource.ResourceKey == localizationResource.ResourceKey)
                                                                             &&
                                                                             (resource.ResourceCultureCode == localizationResource.ResourceCultureCode)));
                if (!isPresent) //if ResourceKey and ResourceCultureCode wasn't found in DB.
                {
                    itemsAddedToDB++;
                    db.Add(localizationResource);
                }
            }
            if (itemsAddedToDB <= 0) return AngularHtmlHelperExtensions.AlertDirective(null, "All items already exist in DB. Nothing added", null, AlertTypesEnum.Warning);
            db.Commit();
            return AngularHtmlHelperExtensions.AlertDirective(null, String.Format("{0} values was added succesfully", itemsAddedToDB), null, AlertTypesEnum.Succes);
        }
    }
}
