using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MT.DataAccess.EntityFramework;
using MT.DomainLogic.PersonalCabinet;
using MT.ModelEntities.Entities;
using MT.Utility.Json;
using MT.Utility.OtherTools;

namespace MT.Web.Controllers
{
    public class PersonalCabinetController : Controller
    {
        private IUnitOfWork db;
        private IUserInfoService _userInfoService;

        public PersonalCabinetController(IUnitOfWork unitOfWork, IUserInfoService userInfoService)
        {
            this.db = unitOfWork;
            _userInfoService = userInfoService;
        }

        /// <summary>
        /// Main page for Personal Cabinet.
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Creates partial view with navigation list.
        /// </summary>
        [ChildActionOnly]
        public ViewResult _leftSide()
        {
            return View();
        }


        /// <summary>
        /// Adds new UserInfo to DB and returns status.
        /// </summary>
        [HttpPost]
        public string Create(UserInfo userInfo)
        {
            if (!ModelState.IsValid)
            {
                ErrorModel modelIsInvalidError = new ErrorModel("Error", new List<string>() { "Model is invalid" }, new List<string>() { "0" });
                return modelIsInvalidError.ToJson();
            }


            try
            {
                _userInfoService.Add(userInfo);
                db.Commit();

            }
            catch (Exception)
            {

                ErrorModel errorAddingtoDB = new ErrorModel("Error", new List<string>() { "Some troubles with DB happened, try to add your info later." }, new List<string>() { "0" });
                return errorAddingtoDB.ToJson();
            }
            ErrorModel noError = new ErrorModel("Succes", new List<string>() { "Resources added succesfully" }, new List<string>() { "0" });

            return noError.ToJson();


        }



    }
}