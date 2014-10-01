using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MT.ModelEntities.Entities;

namespace MT.Web.Areas.Management.Controllers
{
    public class LocalisationController : Controller
    {
        // GET: Management/Localisation
        public ActionResult Index()
        {

            var model = new List<LocalisationResource>
            {
                new LocalisationResource() {ResourceKey = "Login", ResourceCultureCode = "ru-RU", LocalizedResource = "Логин"},
                new LocalisationResource(){ResourceKey = "Password", ResourceCultureCode = "ru-RU", LocalizedResource = "Пароль"},
                new LocalisationResource() {ResourceKey = "Sign", ResourceCultureCode = "ru-RU", LocalizedResource = "Войти"}
            };

            return View(model);
        }
    }
}