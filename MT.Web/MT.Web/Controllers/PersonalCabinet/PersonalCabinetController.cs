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
        private IUserService _userService;

        public PersonalCabinetController(IUnitOfWork unitOfWork, IUserService userService)
        {
            this.db = unitOfWork;
            _userService = userService;
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
        /// Adds new UserInfo to DB or edit Users already existed information and returns status.
        /// </summary>
        [HttpPost]
        public string Create(UserInfo userInfo)
        {
        
            if (!ModelState.IsValid)
            {

                ErrorModel modelIsInvalidError = new ErrorModel("Error", new List<string>(), new List<string>());
                
                foreach (var item in ModelState)
                {
                    foreach (var error in item.Value.Errors)
                    {
                        modelIsInvalidError.ErrorKeysList.Add(item.Key);
                        modelIsInvalidError.ErrorMessagesList.Add(error.ErrorMessage);
                    }
                }

                return modelIsInvalidError.ToJson();
            }

            userInfo.Id = 1; //temporary user's id for testing DB.
            
            try
            {
                _userService.Add(userInfo);
                db.Commit();
            }
            catch (Exception)
            {

                var errorAddingtoDB = new ErrorModel("Error", new List<string>() { "Some troubles with DB happened, try to add your info later." }, new List<string>() { "DataBaseError" });
                return errorAddingtoDB.ToJson();
            }
            
            var succesResult = new JsonNetResult(new { header = "Succes", message = "Resources added succesfully" });
            return succesResult.ToJson();


        }

    }
}