using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MT.DataAccess.EntityFramework;
using MT.DomainLogic.Localization;
using MT.ModelEntities.Entities;
using MT.Utility.Json;
using MT.Utility.OtherTools;
using MT.Web.Models;

namespace MT.Web.Areas.Management.Controllers
{
    public class LocalizationController : Controller
    {
        private IUnitOfWork db;
        private ILocalizationResourceService _localizationResourceService;



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
                return new ErrorModel("Error", new List<string>() { "Model is invalid" }, new List<string>() { "0" }).ToJson();
            }


            int addedEntryies = _localizationResourceService.Create(result.GetLocalizationResources());
            if (addedEntryies < 1) return new ErrorModel("Error", new List<string>() { "All reosources already added to DB" }, new List<string>() { "0" }).ToJson();


            db.Commit();
            return null;


        }












    }
}
