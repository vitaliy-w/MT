using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MT.DataAccess.EntityFramework;
using MT.DomainLogic;
using MT.DomainLogic.PersonalCabinet;
using MT.Utility.Json;
using MT.Utility.OtherTools;
using MT.Web.Models;

namespace MT.Web.Controllers.PersonalCabinet
{

    [Authorize]
    public class EducationController : Controller
    {
        private IUnitOfWork db;
        private IUserEducationService _userEducationService;
        private IUserLoginService _userLoginService;

        public EducationController(IUnitOfWork unitOfWork, IUserEducationService userEducationService, IUserLoginService userLoginService)
        {
            this.db = unitOfWork;
            _userEducationService = userEducationService;
            _userLoginService = userLoginService;
        }

        public ActionResult Index()
        {
            var userEmail = GetUserMailFromFormsAuthentication();
            var result = _userEducationService.GetList(userEmail);
            if (result.Count == 0) return View();
            var viewModel = UserEducationViewModel.CreateList(result);

            return View(viewModel);
        }


        [HttpPost]
        public string AddUserEducation(IEnumerable<UserEducationViewModel> userEducationModelList)
        {
            if (!ModelState.IsValid)
            {
                var modelIsInvalidError = new ErrorModel("Error", new List<string>(), new List<string>());

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


            var mail = GetUserMailFromFormsAuthentication();
            if (_userLoginService.GetUserByEmail(mail) == null) return new ErrorModel("Error", new List<string>() { "We cant find you in our DB" }, new List<string>() { "DB error" }).ToJson();

            try
            {
                foreach (var userEducation in userEducationModelList)
                {

                    var item = userEducation.ConvertToUserEducationItem(mail);
                    _userEducationService.Add(item);

                }

            }
            catch (Exception e)
            {

                var errorAddingtoDB = new ErrorModel("Error", new List<string>() { e.Message }, new List<string>() { "DataBaseError" });
                return errorAddingtoDB.ToJson();
            }
            db.Commit();

            var succesResult = new JsonNetResult(new { header = "Succes", message = "Resources added succesfully" });
            return succesResult.ToJson();

        }

        private string GetUserMailFromFormsAuthentication()
        {
            HttpCookie cookieWithAspxauth = Request.Cookies[".ASPXAUTH"];
            if (cookieWithAspxauth != null)
            {
                var authenticationTicket = FormsAuthentication.Decrypt(cookieWithAspxauth.Value);
                if (authenticationTicket != null)
                {
                    string userId = authenticationTicket.Name;
                    return userId;
                }
            }

            throw new Exception("No .AUTHX found");
        }
    }



}
